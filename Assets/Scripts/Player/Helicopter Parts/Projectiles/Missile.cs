using UnityEngine;

public class Missile : Projectile
{
    //При соприкосновении ракеты с врагом взрывается и наности урон врагу
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHealth collisionHealth = collision.attachedRigidbody.GetComponent<IHealth>();
        collisionHealth.GetDamage((damage * DamageMultiplier) * DamageModificator);
        Destroy(this.gameObject);
    }

    //Движется вперёд
    private void Update()
    {
        transform.Translate(0, speed * SpeedModificator * Time.deltaTime, 0);
    }
}
