using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Guns : MonoBehaviour, IShooter
{
    [SerializeField] private List<Gun> _guns;
    private List<Transform> _gunMountPoints;

    private  List<float> _gunTimers;
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
            if (_gunTimers[startGunIndex] > _guns[startGunIndex].shootingInterval)
            {
                var _bullet = Instantiate(_guns[startGunIndex].projectilePrefab) as GameObject;
                _bullet.transform.SetPositionAndRotation(_gunMountPoints[startGunIndex].position, _gunMountPoints[startGunIndex].rotation);
                _gunTimers[startGunIndex] = 0;
            }
        }
    }

    private void Update()
    {
        for(int i = 0; i < _gunTimers.Count; i++)
        {
            _gunTimers[i] += Time.deltaTime;
        }
    }
    private void Awake()
    {
        _gunTimers = new List<float>();
        for(int i = 0; i < _guns.Count; i++)
        {
            _gunTimers.Add(0);
        }
        _gunMountPoints = GetComponentsInChildren<Transform>().ToList();
        _gunMountPoints.RemoveAt(0);
    }
}
