using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    private string _fileName;

    public void Startup()
    {
        Debug.Log("Data manager starting...");
        status = ManagerStatus.Started;

        _fileName = Path.Combine(Application.persistentDataPath, "save.dat");
    }

    public void SaveGameState()
    {
        Dictionary<string, object> gameState = new Dictionary<string, object>();

        using (FileStream stream = File.Create(_fileName))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            gameState.Add("Currency", Managers.Configuration.Currency);
            gameState.Add("UnlockedObjects", Managers.Configuration.UnlockedObjects);
            gameState.Add("HelicopterData",GetHelicopterData(Managers.Configuration.HelicopterObject));
            formatter.Serialize(stream, gameState);
            stream.Close();
        }
    }

    public void LoadGameState()
    {
        var gamestate = LoadInformation(_fileName);
        Managers.Configuration.Currency = (int)gamestate["Currency"];
        Managers.Configuration.UnlockedObjects = (Dictionary<string, List<bool>>)gamestate["UnlockedObjects"];
        Managers.Configuration.HelicopterData = (List<KeyValuePair<string,int>>)gamestate["HelicopterData"];
    }

    public Dictionary<string,object> LoadInformation(string filename)
    {
        Dictionary<string, object> data;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Open(filename, FileMode.Open);
        data = formatter.Deserialize(stream) as Dictionary<string, object>;
        stream.Close();
        stream.Dispose();
        return data;
    }

    public bool IsThereASave()
    {
      return File.Exists(_fileName);
    }

    public List<KeyValuePair<string,int>> GetHelicopterData(GameObject helicopterObject)
    {
        var helicopterParts = helicopterObject.GetComponentsInChildren<IHelicopterPart>().Reverse().ToList();
        List<KeyValuePair<string, int>> helicopterData = new List<KeyValuePair<string, int>>();
        foreach (IHelicopterPart part in helicopterParts)
        {
            helicopterData.Add(new KeyValuePair<string,int>(part.Type, part.Id));
        }
        return helicopterData;
    }
}
