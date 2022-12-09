using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : MonoBehaviour
{
    [SerializeField] private List<GameObject> _wingsGameObjectList; //All helicopter wings objects

    public List<GameObject> ObjectList
    {
        get { return _wingsGameObjectList; }
    }
}
