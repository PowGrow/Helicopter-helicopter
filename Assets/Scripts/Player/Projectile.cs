using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile: MonoBehaviour, IProjectile
{
    [SerializeField] protected float bulletLifetime = 1f;
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected float damage = 10f;
    protected float damageModificator = 1f;
    protected float speedModificator = 1f;
    protected float lifetimeModificator = 1f;

    public virtual float DamageModificator
    {
        get { return damageModificator; }
        set { damageModificator = value; }
    }

    public virtual float SpeedModificator
    {
        get { return speedModificator; }
        set { speedModificator = value; }
    }

    public virtual float LifetimeModificator
    {
        get { return lifetimeModificator; }
        set { lifetimeModificator = value; }
    }

    private void Awake()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(bulletLifetime);
        Destroy(this.gameObject);
    }
}
