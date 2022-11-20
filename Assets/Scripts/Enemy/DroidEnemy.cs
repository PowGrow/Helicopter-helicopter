using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidEnemy : MonoBehaviour, IEnemy
{
    private SpriteRenderer _sprite;
    private SpawnEnemies spawn;
    public float Health { get; private set; }

    public void GetDamage(float value)
    {
        Health -= value;
        StartCoroutine(BlinkDamage());
        if (Health < 0)
            Die();
    }

    private void Die()
    {
        spawn.enemyList[spawn.lineOfEnemies].Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    private IEnumerator BlinkDamage()
    {
        _sprite.color = Color.red;
        yield return new WaitForSeconds(0.01f);
        _sprite.color = Color.white;
    }

    private void Awake()
    {
        spawn = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnEnemies>();
        Health = 100;
        _sprite = GetComponent<SpriteRenderer>();
    }
}
