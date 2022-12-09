using UnityEngine;

public class UIHealth : MonoBehaviour
{
    private Health _health;
    private Animator _animator;

    private void UpdateHealth(float currentHealth)
    {
        var healthPercent = _health.CurrentHealth / _health.MaxHealth;
        _animator.Play("health_ui", 0, healthPercent);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = Managers.GameObjects.GetObject("Player").GetComponent<Health>();
        _animator.speed = 0;
        _animator.Play("health_ui", 0, 100);
    }
    private void OnEnable()
    {
        _health.OnHealthUpdated += UpdateHealth;
    }

    private void OnDestroy()
    {
        _health.OnHealthUpdated -= UpdateHealth;
    }
}
