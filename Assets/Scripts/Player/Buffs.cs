using UnityEngine;

//Class save all modificator information, and count time when booster should gone, using by Guns when shooting new projectiles and UI elements to visualize duration
public class Buffs : MonoBehaviour
{
    [SerializeField] private float _buffDuration = 30f;
    private float _powerModificator = 1f;
    private float _speedModificator = 1f;
    private float _lifetimeModificator = 1f;

    private float _powerTimer = 0f;
    private float _speedTimer = 0f;

    public float BuffDuration
    {
        get { return _buffDuration; }
    }
    public  float PowerModificator
    {
        get { return _powerModificator; }
        set 
        {
            if(value > 1)
                _powerTimer = _buffDuration;
            _powerModificator = value;
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

    public float PowerTimer
    {
        get { return _powerTimer; }
    }

    public float SpeedTimer
    {
        get { return _speedTimer; }
    }

    private void Update()
    {
        if (_powerTimer > 0)
            _powerTimer -= Time.deltaTime;

        if (_speedTimer > 0)
            _speedTimer -= Time.deltaTime;
    }


}
