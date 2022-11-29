using System;
using TMPro;
using UnityEngine;

public class UIHealth : MonoBehaviour
{
    private Health _health;
    private TextMeshProUGUI _healthLabel;

    private void UpdateHealth()
    {
        var text = _health.CurrentHealth;
        _healthLabel.text = text.ToString();
    }

    private void Awake()
    {
        _health = Managers.GameObjects.GetObject("Player").GetComponent<Health>();
        _healthLabel = this.GetComponent<TextMeshProUGUI>();
        UpdateHealth();
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
