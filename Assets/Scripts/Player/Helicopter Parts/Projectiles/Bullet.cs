using System.Collections;
using UnityEngine;

public class Bullet : Projectile, IProjectile
{
    public bool isEnemy;
    //При соприкосновении снаряда с врагом взрывается и наности урон врагу
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isEnemy)
        {
            IEnemy collisionHealth = collision.attachedRigidbody.GetComponent<IEnemy>();
            collisionHealth.GetDamage((damage * DamageMultiplier) * DamageModificator);
            Destroy(this.gameObject);
        }
        else
        {
            IHealth collisionHealth = collision.attachedRigidbody.GetComponent<IHealth>();
            collisionHealth.GetDamage((damage * DamageMultiplier) * DamageModificator);
            transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y *-1,transform.localScale.z);
            Destroy(this.gameObject);
        }
        Debug.Log("1");
    }
    
    //Движется вперёд
    private void Update()
    {
        if (!isEnemy) { 
            transform.Translate(0, speed * SpeedModificator * Time.deltaTime, 0); 
        }

        else
        {
            transform.Translate(0, -speed * speedModificator * Time.deltaTime, 0);
        }
    }

    private void Start()
    {
        StartCoroutine(InertiaLoss());
        if (isEnemy) transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
    }

    //При потерии инерции пуля падает и уничтожается
    private IEnumerator InertiaLoss()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
