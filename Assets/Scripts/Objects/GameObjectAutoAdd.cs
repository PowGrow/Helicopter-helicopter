using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectAutoAdd : MonoBehaviour
{

    private void Awake()
    {
        Managers.GameObjects.Add(gameObject);
    }

    private void OnDestroy()
    {
        Managers.GameObjects.Remove(gameObject);
    }
}
