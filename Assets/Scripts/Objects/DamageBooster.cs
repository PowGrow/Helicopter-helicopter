using UnityEngine;

public class DamageBooster : BoosterBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ApplyBooster(value);
        Destroy(this.gameObject);            
    }

    private void ApplyBooster(float value)
    {
        _playerBuffs.PowerModificator = base.value;
    }
}
