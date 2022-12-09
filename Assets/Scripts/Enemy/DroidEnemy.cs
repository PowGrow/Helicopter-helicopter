using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidEnemy : MonoBehaviour, IEnemy
{
    private SpriteRenderer _sprite;
    private SpawnEnemies spawn;
    [SerializeField] public float _speed = 20f;
    public GameObject bulletPrefab;
    public bool start = true;
    public float damage = 1f;
    public float Health;
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }
    public void GetDamage(float value)
    {
        Health -= value;
        StartCoroutine(BlinkDamage());
        if (Health < 0)
            Die();
    }

    private void Die()
    {
        spawn.curentLineEnemiesCount -= 1;
        spawn.enemyList.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    private IEnumerator BlinkDamage()
    {
        _sprite.color = Color.red;
        yield return new WaitForSeconds(0.03f);
        _sprite.color = Color.white;
    }

    private void Awake()
    {
        spawn = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnEnemies>();
        Health = 10;
        _sprite = GetComponent<SpriteRenderer>();
        damage = 1f;
    }
    public IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f,2.3f));
            if (start)
            {

                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = new Vector2(this.transform.position.x, this.transform.position.y-0.5f);
                bullet.GetComponent<Bullet>().isEnemy = true;
                bullet.GetComponent<Bullet>().DamageMultiplier = damage;
            }
            Debug.Log("работает");
        }
    }
}
