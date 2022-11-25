using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAimMissile : Projectile
{
     internal GameObject _target; //Поле цели ракеты

    private void Update()
    {
        //Двигается вперёд если цели нет, если есть, то двигается к цели
        if(_target == null)
        {
            transform.Translate(0, speed * SpeedModificator * Time.deltaTime, 0);
        }
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, _target.transform.position, speed * SpeedModificator * Time.deltaTime);
            transform.up = _target.transform.position - transform.position;
        }
    }
    //При соприкосновении ракеты с врагом взрывается и наности урон врагу
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IEnemy enemy = collision.transform.GetComponent<IEnemy>();
        enemy.GetDamage((damage * DamageMultiplier) * DamageModificator);
        Destroy(this.gameObject);
    }

    //Метод вызываемый детектором боеголовки и указыващий цель для ракеты
    public void SetAimTarget(GameObject target)
    {
        _target = target;
    }
}
