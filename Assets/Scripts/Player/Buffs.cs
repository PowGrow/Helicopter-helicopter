using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    [SerializeField] private float _buffDuration = 30f;
    private float _damageModificator = 1f;
    private float _speedModificator = 1f;
    private float _lifetimeModificator = 1f;

    private float _damageTimer = 0f;
    private float _speedTimer = 0f;

    public  float DamageModificator
    {
        get { return _damageModificator; }
        set 
        {
            if(value > 1)
                _damageTimer = _buffDuration;
            _damageModificator = value;
        }
    }

    public  float SpeedModificator
    {
        get { return _speedModificator; }
        set 
        {
            if (value > 1)
                _speedTimer = _buffDuration;
            _speedModificator = value;
        }
    }

    public  float LifetimeModificator
    {
        get { return _lifetimeModificator; }
        set { _lifetimeModificator = value; }
    }

    public float DamageTimer
    {
        get { return _damageTimer; }
    }

    public float SpeedTimer
    {
        get { return _speedTimer; }
    }

    private void Update()
    {
        if (_damageTimer > 0)
            _damageTimer -= Time.deltaTime;

        if (_speedTimer > 0)
            _speedTimer -= Time.deltaTime;
    }


}
