using System.Linq;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float _currentHealth = 1f;
    private float _armor = 0f;

    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public float CurrentHealth
    {
        get { return _currentHealth; }
    }

    public float Armor
    {
        get { return _armor;}
        set { _armor = value; }
    }

    public void GetDamage(float value)
    {
        _currentHealth -= value - (value / 10 * Armor);
        Messenger.Broadcast(GameEvent.PLAYER_HEALTH_UPDATED);
        if (_currentHealth < 0)
            Time.timeScale = 0;
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
