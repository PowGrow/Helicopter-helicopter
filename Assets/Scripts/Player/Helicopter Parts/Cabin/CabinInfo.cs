using System;
using System.Collections.Generic;
using UnityEngine;

public class CabinInfo : MonoBehaviour, IHelicopterPart
{
    [SerializeField] private Cabin  _cabin;//Текущая кабина ScriptableObject, должен быть прикреплён для получения всей информации
    [SerializeField] private int    _id;//ID кабины
    [SerializeField] private float  _cabinHealth = 0f; //Поле здоровья кабины вертолёта
    [SerializeField] private float  _cabinArmor = 0f; //Поле брони кабины вертолёта
    [SerializeField] private Sprite _sprite;//Спрайт кабины
    [SerializeField] private int    _price;             //Цена улучшения
    [SerializeField] private string _description;    //Описание крыльев

    private Health _playerHealth;

    //Публичные свойства для приватных полей
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public float CabinHealth
    {
        get { return _cabinHealth; }
        set { 
                _cabinHealth = value;
                _playerHealth.MaxHealth = value;
            }
    }
    public float CabinArmor
    {
        get { return _cabinArmor; }
        set { _cabinArmor = value; }
    }
    public Sprite Sprite
    {
        get { return _sprite; }
        set { _sprite = value; }
    }
    public int Price
    {
        get { return _price; }
        set { _price = value; }
    }
    public string Description
    {
        get { return _cabin.Description; }
        set { _description = value; }
    }
    public string Type
    {
        get { return _cabin.GetType().ToString(); }
    }
    public List<GameObject> ObjectList
    {
        get { return this.transform.parent.GetComponent<Cabins>().ObjectList; }
    }

    public GameObject partGameObject
    {
        get { return this.gameObject; }
    }

    //Получаем значение здоровья и брони в зависимости от установленной кабины вертолёта
    private void SetCabinInfoFromContainer() 
    {
        Utils.SetObjectInfo(this, _cabin);
    }

    private void Awake()
    {
        _playerHealth = transform.parent.parent.GetComponent<Health>();
    }

    private void OnEnable()
    {
        SetCabinInfoFromContainer();
    }
}
