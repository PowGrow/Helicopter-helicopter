using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    private float _damageModificator = 1f;
    private float _speedModificator = 1f;
    private float _lifetimeModificator = 1f;

    public  float DamageModificator
    {
        get { return _damageModificator; }
        set { _damageModificator = value; }
    }

    public  float SpeedModificator
    {
        get { return _speedModificator; }
        set { _speedModificator = value; }
    }

    public  float LifetimeModificator
    {
        get { return _lifetimeModificator; }
        set { _lifetimeModificator = value; }
    }


}
