using System;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private float maxHealth = 100f;
    private float _currentHealth = 1f;
    private SpriteRenderer _spriteRenderer;

    public Action<EnemyBehavior> OnHealthLowered;

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
        }
    }

    public void GetDamage(float value)
    {
        _currentHealth -= value;
        CheckCurrentBehavior(_currentHealth);
        if (_currentHealth <= 0)
            Die();
        else
            StartCoroutine(BlinkDamage());
    }

    private void CheckCurrentBehavior(float health)
    {
        if (health < 25)
            OnHealthLowered?.Invoke(EnemyBehavior.defensive);
        else if (health < 50)
            OnHealthLowered?.Invoke(EnemyBehavior.careful);
    }

    private IEnumerator BlinkDamage()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.01f);
        _spriteRenderer.color = Color.white;
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
