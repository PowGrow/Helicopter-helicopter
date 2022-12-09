using UnityEngine;

public class AidBooster : BoosterBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ApplyBooster(value);
        Destroy(this.gameObject);
    }

    private void ApplyBooster(float value)
    {
        _playerBuffs.gameObject.GetComponent<IHealth>().GetHealing(base.value);
    }
}
