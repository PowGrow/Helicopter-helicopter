using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile: MonoBehaviour, IProjectile
{
    [SerializeField] private float _bulletLifetime = 1f;
    [SerializeField] protected float speed = 10f;
    [SerializeField] private float _damage = 10f;
    private float _damageModificator = 1f;
    private float _speedModificator = 1f;
    private float _lifetimeModificator = 1f;

    public virtual float DamageModificator
    {
        get { return _damageModificator; }
        set { _damageModificator = value; }
    }

    public virtual float SpeedModificator
    {
        get { return _speedModificator; }
        set { _speedModificator = value; }
    }

    public virtual float LifetimeModificator
    {
        get { return _lifetimeModificator; }
        set { _lifetimeModificator = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            IEnemy enemy = collision.transform.GetComponent<IEnemy>();
            enemy.GetDamage(_damage * _damageModificator);
        }
        if(collision.gameObject.tag != "Missile")
            Destroy(this.gameObject);
    }

    private void Awake()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_bulletLifetime);
        Destroy(this.gameObject);
    }
}
