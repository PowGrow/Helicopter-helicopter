using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private float maxHealth = 100f;
    private float _currentHealth = 1f;
    private float _armor = 0f;

    public Action OnHealthUpdated;

    public float MaxHealth
    {
        get { return maxHealth; }
        set 
        { 
            maxHealth = value;
            CurrentHealth = value;
        }
    }

    public float CurrentHealth
    {
        get { return _currentHealth; }
        private set 
        { 
            _currentHealth = value;
            OnHealthUpdated?.Invoke();
        }
    }

    public float Armor
    {
        get { return _armor;}
        set { _armor = value; }
    }

    public void GetDamage(float value)
    {
        CurrentHealth -= value - (value / 10 * Armor);
        if (_currentHealth < 0)
            Time.timeScale = 0;
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

}
