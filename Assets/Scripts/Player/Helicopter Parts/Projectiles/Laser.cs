using UnityEngine;

public class Laser : Projectile
{
    //TODO урон нескольким врагам
    //При соприкосновении волны с врагом взрывается и наности урон врагу 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IEnemy enemy = collision.transform.GetComponent<IEnemy>();
        enemy.GetDamage((damage * DamageMultiplier) * DamageModificator);
        Destroy(this.gameObject);
    }

    //Движется вперёд
    private void Update()
    {
        transform.Translate(0, speed * SpeedModificator * Time.deltaTime, 0);
    }
}
