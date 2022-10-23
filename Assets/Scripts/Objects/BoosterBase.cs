using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoosterBase : MonoBehaviour
{
    [SerializeField] protected float value;

    protected abstract void ApplyBooster(float _value);
}
