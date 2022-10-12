using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletLifetime = 1f;
    private float _speed = 10f;
    private float _damage = 10f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            IEnemy enemy = collision.transform.GetComponent<IEnemy>();
            enemy.GetDamage(_damage);
        }

        Destroy(this.gameObject);
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
        yield return new WaitForSeconds(_bulletLifetime);
        Destroy(this.gameObject);
    }
}
