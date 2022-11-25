using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : MonoBehaviour
{
    [SerializeField] private List<GameObject> _wingsGameObjectList; //Список всех объектов крыльев вертолёта

    //Публичное свойство реализующее интерфейс IHelicopterPart, передающее список всех объектов родительского контейнера
    public List<GameObject> ObjectList
    {
        get { return _wingsGameObjectList; }
    }
}
