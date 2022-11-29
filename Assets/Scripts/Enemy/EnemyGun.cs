using System.Linq;
using UnityEngine;

public class EnemyGun : MonoBehaviour, IShooter
{
    [SerializeField] private Gun _gun;
    [SerializeField] private Transform _shootingPoint;
    private float _timer = 0f;
    public void Fire()
    {
        if(_timer >= _gun.ShootingInterval)
        {
            var bullet = Instantiate(_gun.ProjectilePrefab);
            Managers.GameObjects.Projectiles.Last().DamageMultiplier = _gun.DamageMultiplier;
            bullet.tag = this.tag;
            bullet.transform.SetPositionAndRotation(_shootingPoint.position, _shootingPoint.rotation);
            _timer = 0;
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }
}