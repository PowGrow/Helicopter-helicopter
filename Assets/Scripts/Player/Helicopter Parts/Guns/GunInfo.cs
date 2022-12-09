using System.Collections.Generic;
using UnityEngine;

public class GunInfo : MonoBehaviour, IHelicopterPart
{
    //All this serialize fields,except _gun need only to view infromation about gun in editor in playmode, if all data was loaded
    [SerializeField] private Gun                        _gun; 
    [SerializeField] private int                        _Id;
    [SerializeField] private float                      _shootingInterval;
    [SerializeField] private float                      _damageMultiplier;
    [SerializeField] private GameObject                 _projectilePrefab; 
    [SerializeField] private Sprite                     _sprite;
    [SerializeField] private int                        _price;
    [SerializeField] private string                     _description;

    private GunTrigger _gunTrigger;
    private SpriteRenderer _spriteRenderer;

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

    //load information from scriptableobject to visualize it in editor
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
