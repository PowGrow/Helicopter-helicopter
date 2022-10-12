using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Guns : MonoBehaviour, IShooter
{
    [SerializeField] private List<Gun> _guns;
    private List<Transform> _gunMountPoints;

    private float _timer;
    public void Fire()
    {
        if(_guns.Count == 1)
            CreateBullet(0);
        else
            CreateBullet(1);

    }

    private void CreateBullet(int startGunIndex)
    {
        for (; startGunIndex < _guns.Count; startGunIndex++)
        {
            if (_timer > _guns[startGunIndex].shootingInterval)
            {
                var _bullet = Instantiate(_guns[startGunIndex].bulletPrefab) as GameObject;
                _bullet.transform.position = _gunMountPoints[startGunIndex].position;
                _bullet.transform.rotation = _gunMountPoints[startGunIndex].rotation;
            }
        }
        _timer = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }
    private void Awake()
    {
        _timer = 0;
        _gunMountPoints = GetComponentsInChildren<Transform>().ToList();
        _gunMountPoints.RemoveAt(0);
    }
}
