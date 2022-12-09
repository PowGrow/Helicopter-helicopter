using UnityEngine;

public class Laser : Projectile
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHealth collisionHealth = collision.transform.GetComponent<IHealth>();
        collisionHealth.GetDamage((damage * DamageMultiplier) * DamageModificator);
    }

    private void Update()
    {
        transform.Translate(0, speed * SpeedModificator * Time.deltaTime, 0);
    }
}
