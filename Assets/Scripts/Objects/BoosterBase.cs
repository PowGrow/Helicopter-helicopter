using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterBase : MonoBehaviour
{
    [SerializeField] protected float value;
    protected Buffs _playerBuffs;

    private void Awake()
    {
        _playerBuffs = Managers.GameObjects.GetObject("Player").GetComponent<Buffs>();
    }
}
