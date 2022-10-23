using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjects : MonoBehaviour
{
    private static List<GameObject> _gameObjectsList;

    private void Awake()
    {
        _gameObjectsList = new List<GameObject>();
    }

    public static void Add(GameObject gameObject)
    {
        _gameObjectsList.Add(gameObject);
    }

    public static void Remove(GameObject gameObject)
    {
        _gameObjectsList.Remove(gameObject);
    }

    public static GameObject Get(string tag)
    {
        foreach (GameObject gameObject in _gameObjectsList)
        {
            if (gameObject.tag == tag)
                return gameObject;
        }
        return null;
    }
}
