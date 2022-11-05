using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : DroidEnemy
{
    private GameObject player;
    private Rigidbody2D rb;
    public float offset;
    public float speed = 1;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //пока не доделано
        GetDamage(100);
    }
    private IEnumerator DestroyByTime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
