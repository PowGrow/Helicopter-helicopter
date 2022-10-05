using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidEnemy : MonoBehaviour, IEnemy
{
    private SpriteRenderer _sprite;
    public float Health { get; private set; }

    public void GetDamage(float value)
    {
        Health -= value;
        StartCoroutine(BlinkDamage());
        if (Health < 0)
            Die();
    }

    private void Awake()
    {
        Health = 100;
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    private IEnumerator BlinkDamage()
    {
        _sprite.color = Color.red;
        yield return new WaitForSeconds(0.01f);
        _sprite.color = Color.white;
    }

}
