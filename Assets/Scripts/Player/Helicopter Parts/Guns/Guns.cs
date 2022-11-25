using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Guns : MonoBehaviour, IShooter
{
    [SerializeField] private List<GameObject> _gunsGameObjectList; //Список объектов всех пушек
    [SerializeField] private List<GunInfo> _gunInfoList;
    [SerializeField] private Buffs _buffs; //Ссылка на экземпляр класса обрабатывающего баффы полученные игроком во время вылета

    private static Guns _instance;

    public static Guns Instance
    {
        get { return _instance;}
    }
    public List<GameObject> ObjectList
    {
        get { return _gunsGameObjectList; }
    }
    public List<GunInfo> GunInfoList
    {
        get { return _gunInfoList; }
    }
    //Фассадирующий метод стрельбы
    public void Fire()
    {
        TryToShootBullet(this);
    }

    //Пытаемся выстрелить, если успешно, то устанавливаем снаряду модификатор скорости и силы, в зависимости от имеющихся бафов
    private void TryToShootBullet(Guns guns)
    {
        for (int currentGunIndex = 0; currentGunIndex < _gunsGameObjectList.Count; currentGunIndex++)
        {
            if (_gunsGameObjectList[currentGunIndex].activeSelf)
            {
                var bullet = _gunInfoList[currentGunIndex].GunTrigger.Click(_gunsGameObjectList[currentGunIndex].transform.position, _gunsGameObjectList[currentGunIndex].transform.rotation);
                if(bullet != null)
                {
                    var projectile = Managers.GameObjects.Projectiles.Last();
                    projectile.DamageMultiplier = _gunInfoList[currentGunIndex].DamageMultiplier;
                    projectile.DamageModificator = _buffs.DamageModificator;
                    projectile.SpeedModificator = _buffs.SpeedModificator;
                }
            }
        }
    }

    //Устанавливаем все пушки на нужные места в зависимости от их количества
    public void SetupGunMountPoints(int gunsSummCount, List<Vector2> wingsMountPoints)
    {
        //Сначала отключаем все пушки
        foreach(GameObject gun in _gunsGameObjectList)
        {
            gun.SetActive(false);
        }
        //Затем активируем тольно нужные и устанавливаем им нужное положение
        for(int i = 0; i < _gunsGameObjectList.Count; i++)
        {
            if (i < gunsSummCount)
            {
                _gunsGameObjectList[i].transform.localPosition = wingsMountPoints[i];
                _gunsGameObjectList[i].SetActive(true);
            }
        }
    }

    //Заменяем пушку на новую в зависимости от её типа
    public void SwapGun(int gunId, Gun gun)
    {
        var gunInfo = _gunsGameObjectList[gunId].GetComponent<GunInfo>();
        Messenger.Broadcast(GameEvent.CONFIGURATION_CHANGED);
    }

    //Загружает информацию о пушках при старте
    private void LoadGunInfo()
    {
        _gunInfoList.Clear();
        for(int gunIndex = 0; gunIndex < _gunsGameObjectList.Count; gunIndex++)
        {
            var gunInfo = _gunsGameObjectList[gunIndex].GetComponent<GunInfo>();
            if (gunInfo == null)
                _gunInfoList.Add(null);
            else
                _gunInfoList.Add(gunInfo);
        }
    }
    

    private void SetInstance()
    {
        if (_instance == null)
            _instance = this;
    }

    private void Awake()
    {
        SetInstance();
    }

    private void Start()
    {
        LoadGunInfo();
    }

}
