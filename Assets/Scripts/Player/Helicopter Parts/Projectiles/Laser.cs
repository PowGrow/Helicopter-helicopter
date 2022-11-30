using UnityEngine;

public class Laser : Projectile
{
    //TODO урон нескольким врагам
    //При соприкосновении волны с врагом взрывается и наности урон врагу 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHealth collisionHealth = collision.transform.GetComponent<IHealth>();
        collisionHealth.GetDamage((damage * DamageMultiplier) * DamageModificator);
    }

    //Движется вперёд
    private void Update()
    {
        transform.Translate(0, speed * SpeedModificator * Time.deltaTime, 0);
    }
}
