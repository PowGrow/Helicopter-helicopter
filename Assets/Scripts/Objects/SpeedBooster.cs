using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : BoosterBase
{
    private Buffs _playerBuffs;


    private void Awake()
    {
        _playerBuffs = GameObjects.Get("Player").GetComponent<Buffs>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            ApplyBooster(value);
            Destroy(this.gameObject);
        }

    }

    protected override void ApplyBooster(float value)
    {
        _playerBuffs.SpeedModificator = base.value;
    }
}
