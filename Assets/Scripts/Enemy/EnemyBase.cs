using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IEnemy
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

    private void Awake()
    {
        Health = 100;
        _sprite = GetComponent<SpriteRenderer>();
    }
}
