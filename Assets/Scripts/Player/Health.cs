using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private TextMeshProUGUI _deathLabel;
    private float _currentHealth = 1f;
    private float _armor = 0f;

    public Action<float> OnHealthUpdated;

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
            if (_currentHealth <= 0)
                _currentHealth = 0;
            OnHealthUpdated?.Invoke(_currentHealth);
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
        if (_currentHealth <= 0)
            StartCoroutine(Die());
    }

    public void GetHealing(float value)
    {
        CurrentHealth += value;
    }

    private IEnumerator Die()
    {
        _deathLabel.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        _deathLabel.gameObject.SetActive(false);
        _deathLabel.fontSize = 1;
        Managers.Levels.GoToPrevious();
    }

}
