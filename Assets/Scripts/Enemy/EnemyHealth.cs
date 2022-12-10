using System;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private float maxHealth = 100f;
    private float _currentHealth = 1f;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;

    public Action<float> OnHealthCnaged;
    public Action OnEnemyDying;
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
        OnHealthCnaged?.Invoke(_currentHealth);
        if (_currentHealth <= 0)
            Die();
        else
            StartCoroutine(Blink(Color.red));
    }

    public void GetHealing(float value)
    {
        _currentHealth += value;
        OnHealthCnaged?.Invoke(_currentHealth);
        StartCoroutine(Blink(Color.green));
    }

    private IEnumerator Blink(Color color)
    {
        _spriteRenderer.color = color;
        yield return new WaitForSeconds(0.01f);
        _spriteRenderer.color = Color.white;
    }

    private void Die()
    {
        _collider.enabled = false;
        OnEnemyDying?.Invoke();
    }

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }
}
