using System;
using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private Buffs _buffs;

    private TextMeshProUGUI _timerLabel;

    private void Awake()
    {
        _timerLabel = this.GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        if(_label.name == "Damage label" && _buffs.DamageModificator > 1)
        {
            _label.color = Color.white;
            _timerLabel.text = Math.Round((decimal)_buffs.DamageTimer,0).ToString();
        }
        else if(_label.name == "Speed label" && _buffs.SpeedModificator > 1)
        {
            _label.color = Color.white;
            _timerLabel.text = Math.Round((decimal)_buffs.SpeedTimer, 0).ToString();
        }
        else
        {
            _timerLabel.text = " ";
            _label.color = Color.gray;
        }
    }
}
