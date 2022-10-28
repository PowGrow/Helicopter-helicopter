using UnityEngine;

public class SpeedBooster : BoosterBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            ApplyBooster(value);
            Destroy(this.gameObject);
        }

    }

    private void ApplyBooster(float value)
    {
        _playerBuffs.SpeedModificator = base.value;
    }
}
