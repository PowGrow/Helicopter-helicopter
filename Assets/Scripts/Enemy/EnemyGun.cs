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
            Managers.GameObjects.Projectiles.Last().DamageModificator = 0.5f;
            Managers.GameObjects.Projectiles.Last().SpeedModificator = 0.5f;
            bullet.tag = this.tag;
            bullet.layer = 11; // 11 - EnemyProjectiles
            bullet.transform.SetPositionAndRotation(_shootingPoint.position, transform.rotation);
            _timer = 0;
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }
}
