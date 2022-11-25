using System.Collections.Generic;
using UnityEngine;

public class Cabins : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cabinGameObjectList; //Список всех объектов кабин вертолёта

    //Публичное свойство реализующее интерфейс IHelicopterPart, передающее список всех объектов родительского контейнера
    public List<GameObject> ObjectList
    {
        get{ return _cabinGameObjectList; }
    }
}
