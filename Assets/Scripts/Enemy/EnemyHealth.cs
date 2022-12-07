using System;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private float maxHealth = 100f;
    private float _currentHealth = 1f;
    private SpriteRenderer _spriteRenderer;

    public Action<float> OnHealthCnaged;
    public Action<GameObject> OnEnemyDying;
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
            StartCoroutine(BlinkDamage());
    }

    private IEnumerator BlinkDamage()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.01f);
        _spriteRenderer.color = Color.white;
    }

    private void Die()
    {
        OnEnemyDying?.Invoke(this.gameObject);
        Destroy(this.gameObject);
    }

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
