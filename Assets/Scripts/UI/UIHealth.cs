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
        Messenger.AddListener(GameEvent.PLAYER_HEALTH_UPDATED, UpdateHealth);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.PLAYER_HEALTH_UPDATED, UpdateHealth);
    }
}
