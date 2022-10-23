using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectAutoAdd : MonoBehaviour
{

    private void Awake()
    {
        GameObjects.Add(gameObject);
    }

    private void OnDestroy()
    {
        GameObjects.Remove(gameObject);
    }
}
