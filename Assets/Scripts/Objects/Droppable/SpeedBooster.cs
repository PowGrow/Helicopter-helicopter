using UnityEngine;

public class SpeedBooster : BoosterBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ApplyBooster(value);
        Destroy(this.gameObject);
    }

    private void ApplyBooster(float value)
    {
        _playerBuffs.SpeedModificator = base.value;
    }

    public void DropItem()
    {
        throw new System.NotImplementedException();
    }
}
