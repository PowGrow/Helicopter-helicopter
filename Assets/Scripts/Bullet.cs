using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 10f;
    private float _damage = 10f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            IEnemy enemy = collision.transform.GetComponent<IEnemy>();
            enemy.GetDamage(_damage);
        }

        Destroy();
    }

    private void Awake()
    {
        StartCoroutine(Destroy());
    }

    private void Update()
    {
        transform.Translate(0, _speed * Time.deltaTime, 0);
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
