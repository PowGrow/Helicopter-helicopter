using System.Collections;
using UnityEngine;

public class Bullet : Projectile, IProjectile
{
    private Rigidbody2D _rigidBody;
    //При соприкосновении снаряда с врагом взрывается и наности урон врагу
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

    private void Start()
    {
        StartCoroutine(InertiaLoss());
    }

    //При потерии инерции пуля падает и уничтожается
    private IEnumerator InertiaLoss()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
