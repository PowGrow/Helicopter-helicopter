using System.Collections;
using UnityEngine;

//Any projectile base class
public class Projectile: MonoBehaviour, IProjectile
{
    [SerializeField] protected float bulletLifetime = 1f;
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected float damage = 10f;
    protected float damageMultiplier = 1f;
    protected float damageModificator = 1f;
    protected float speedModificator = 1f;
    protected float lifetimeModificator = 1f;

    public virtual float DamageMultiplier
    {
        get { return damageMultiplier; }
        set { damageMultiplier = value; }
    }
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
        Managers.GameObjects.Projectiles.Add(this);
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(bulletLifetime);
        Managers.GameObjects.Projectiles.Remove(this);
        Destroy(this.gameObject);
    }
}
