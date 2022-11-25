using System.Collections.Generic;
using UnityEngine;

public class GunInfo : MonoBehaviour, IHelicopterPart
{
    [SerializeField] private Gun                        _gun; //Текущая пушка ScriptableObject, должен быть прикреплён для получения всей информации
    [SerializeField] private int                        _Id; //ID пушки
    [SerializeField] private float                      _shootingInterval; //Поле скорости стрельбы
    [SerializeField] private float                      _damageMultiplier; //Поле модификатора урона пушки
    [SerializeField] private GameObject                 _projectilePrefab; //Префаб снаряда
    [SerializeField] private Sprite                     _sprite;//Спрайт пушки
    [SerializeField] private int                        _price;//Цена улучшения
    [SerializeField] private string                     _description;//Описание пушки

    private GunTrigger _gunTrigger;
    private SpriteRenderer _spriteRenderer;

    //Публичные свойства для приватных полей
    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    public float ShootingInterval
    {
        get { return _shootingInterval; }
        private set { _shootingInterval = value; }
    }
    public float DamageMultiplier
    {
        get { return _damageMultiplier; }
        private set { _damageMultiplier = value; }
    }
    public GameObject ProjectilePrefab
    {
        get { return _projectilePrefab; }
        private set { _projectilePrefab = value; }
    }
    public Sprite Sprite
    {
        get { return _sprite; }
        set 
        { 
            _sprite = value;
            _spriteRenderer.sprite = value;
        }
    }
    public int Price
    {
        get { return _price; }
        set { _price = value; }
    }
    public string Description
    {
        get { return _gun.Description; }
        set { _description = value; }
    }
    public string Type
    {
        get { return _gun.GetType().ToString(); }
    }
    public GunTrigger GunTrigger
    {
        get { return _gunTrigger; }
    }
    public Gun Gun
    {
        get { return _gun; }
        set 
        { 
            _gun = value;
            SetGunInfoFromContainer();
        }
    }


    public List<GameObject> ObjectList
    {
        get { return this.transform.parent.GetComponent<Guns>().ObjectList; }
    }

    public GameObject partGameObject
    {
        get { return this.gameObject; }
    }

    //Получаем всю информацию о пушке из заранее прикреплённого ScriptableObject (Gun _gun)
    public void SetGunInfoFromContainer()
    {
        Utils.SetObjectInfo(this, _gun);
    }

    private void Awake()
    {
        _gunTrigger = GetComponent<GunTrigger>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetGunInfoFromContainer();
    }
}
