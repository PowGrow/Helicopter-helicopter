using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float _currentHealth = 1f;

    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public float CurrentHealth
    {
        get { return _currentHealth; }
    }

    public void GetDamage(float value)
    {
        _currentHealth -= value;
        Messenger.Broadcast(GameEvent.PLAYER_HEALTH_UPDATED);
        if (_currentHealth < 0)
            Die();
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    private void Awake()
    {
        _currentHealth = maxHealth;
    }
}
