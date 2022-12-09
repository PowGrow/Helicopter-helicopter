using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : Projectile
{
    public GameObject player;
    private Rigidbody2D rb;
    public float offset;
    public bool isEnemy;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnEnable()
    {
        StartCoroutine(DestroyByTime());
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        LookAtPlayer(direction);
        direction = new Vector2(direction.x, direction.y);
        EnemyMove(direction.normalized);
    }
    void EnemyMove(Vector3 direction)//Движкние к игроку
    {
        rb.velocity = direction * speed * Time.deltaTime;
    }
    void LookAtPlayer(Vector3 direction)//Постоянный поворот на игрока
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
    }
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
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
            Destroy(this.gameObject);
        }
        Debug.Log("1");
    }
    private IEnumerator DestroyByTime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
