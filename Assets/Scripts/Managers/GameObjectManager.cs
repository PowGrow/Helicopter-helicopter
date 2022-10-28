using UnityEngine;
using System.Collections.Generic;
public class GameObjectManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public List<GameObject> allObjects = new List<GameObject>();

    public void Startup()
    {
        Debug.Log("GameObjectManager starting...");

        status = ManagerStatus.Started;
    }

    public void ClearList()
    {
        allObjects.Clear();
    }

    public GameObject GetObject(string tag)
    {
        foreach (GameObject obj in allObjects)
        {
            if(obj.tag == tag)
                return obj;
        }
        return null;
    }

    public void Add(GameObject _gameObject)
    {
        allObjects.Add(_gameObject);
    }

    public void Remove(GameObject _gameObject)
    {
        allObjects.Remove(_gameObject);
    }
}
