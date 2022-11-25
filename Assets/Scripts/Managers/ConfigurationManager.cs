using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigurationManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    //ѕоле текущего количество валюты игрока
    private int _currency;

    private Dictionary<string, List<bool>> _unlockedObjects = new Dictionary<string, List<bool>>(3); //3 - количество деталей вертолЄта: Cabin,Gun,Wing
    private GameObject _helicopterObject;
    private List<KeyValuePair<string, int>> _helicopterData = new List<KeyValuePair<string, int>>();
    public Dictionary<string, List<bool>> UnlockedObjects
    {
        get { return _unlockedObjects; }
        set { _unlockedObjects = value; }
    }
    public GameObject HelicopterObject
    {
        get { return _helicopterObject; }
    }

    public List<KeyValuePair<string, int>> HelicopterData
    {
        get { return _helicopterData; }
        set { _helicopterData = value; }
    }

    //ѕубличное свойство дл€ получени€ и установлени€ количества валюты
    public int Currency
    {
        get { return _currency; }
        set
        {
            _currency = value;
            var sceneId = SceneManager.GetActiveScene().buildIndex;
            if (sceneId != 0 && sceneId != 1)
                Messenger.Broadcast(GameEvent.CURRENCY_CHANGED);
        }
    }

    public void Startup()
    {
        Debug.Log("Configuration manager starting...");
        Initialize();
        status = ManagerStatus.Started;
    }

    private void Initialize()
    {
        Currency = 200;
        DefaultConfiguration();
    }

    public void DefaultConfiguration() //»нициализаци€ пустой конфигурации при старте новой игре.
    {
        _helicopterData.Clear();
        _unlockedObjects.Clear();
        _unlockedObjects.Add("Cabin", new List<bool>(Enumerable.Repeat(false,4).ToList()));
        _unlockedObjects.Add("Gun", new List<bool>(Enumerable.Repeat(false, 11).ToList()));
        _unlockedObjects.Add("Wing", new List<bool>(Enumerable.Repeat(false, 4).ToList()));
        foreach(var item in _unlockedObjects)
            item.Value[0] = true;
    }

    public void SetHelicopterGameObject(GameObject helicopterObject)
    {
        _helicopterObject = helicopterObject;
        if (HelicopterData.Count != 0)
            LoadHelicopterData(HelicopterData);
    }

    public void LoadHelicopterData(List<KeyValuePair<string, int>> helicopterData)
    {
        var helicopterParts = _helicopterObject.GetComponentsInChildren<IHelicopterPart>().Reverse().ToList();
        PreparationsController.Instance.TryToChangePart(helicopterParts[0], helicopterData[0].Value);
        PreparationsController.Instance.TryToChangePart(helicopterParts[1], helicopterData[1].Value);
        helicopterParts = _helicopterObject.GetComponentsInChildren<IHelicopterPart>().ToList();
        helicopterData.Reverse();
        GameObject lastSelectedGameObject = null;
        for(int partIndex = 0; partIndex < helicopterParts.Count; partIndex++)
        {
            if (helicopterParts[partIndex].Type == "Gun")
            {
                lastSelectedGameObject = PreparationsController.Instance.TryToChangePart(helicopterParts[partIndex], helicopterData[partIndex].Value);
            }

        }
        if(Managers.Levels.SceneId() == 2)
            PreparationsController.Instance.ClearSelection(lastSelectedGameObject);
    }


}