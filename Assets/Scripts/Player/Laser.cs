using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Projectile
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            IEnemy enemy = collision.transform.GetComponent<IEnemy>();
            enemy.GetDamage(damage * damageModificator);
        }
        if (collision.gameObject.tag != "Missile")
            Destroy(this.gameObject);
    }

    private void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
