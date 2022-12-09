using System.Collections;
using UnityEngine;

public class Bullet : Projectile, IProjectile
{
    private IEnumerator InertiaLoss()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHealth collisionHealth = collision.attachedRigidbody.GetComponent<IHealth>();
        collisionHealth.GetDamage((damage * DamageMultiplier) * DamageModificator);
        Destroy(this.gameObject);
    }
    private void Update()
    {
        transform.Translate(0, speed * SpeedModificator * Time.deltaTime, 0);
    }
    private void Start()
    {
        StartCoroutine(InertiaLoss());
    }
}
