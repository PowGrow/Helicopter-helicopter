using UnityEngine;

//Класс реализующий спусковой крючок пушки
public class GunTrigger : MonoBehaviour
{
    private float _timer; //Таймер для учёта скорости стрельбы пушки
    private GunInfo _gunInfo; //Поле информации о пушке

    //Нажатие на курок вызывает создание снаряда и возвращение полученного экземпляра IProjectile вызывающей функции, если прошёл нужны интервал времени после последнего создания объекта
    public GameObject Click(Vector2 gunPosition, Quaternion gunRotation)
    {
        if(_timer >= _gunInfo.ShootingInterval)
        {
            var _bullet = Instantiate(_gunInfo.ProjectilePrefab);
            _bullet.transform.SetPositionAndRotation(gunPosition, gunRotation);
            _timer = 0;
            return _bullet;
        }
        return null;
    }

    void Update()
    {
        _timer += Time.deltaTime;    //Считаем прошедшее время
    }

    private void Awake()
    {
        _gunInfo = GetComponent<GunInfo>(); //Получаем информацию о пушке
    }

    private void Start()
    {
        _timer = 0; //Инициализируем поле таймера
    }
}
