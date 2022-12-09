using System;
using TMPro;
using UnityEngine;
//Класс выводящий информацию о оставшемся времени бафов игрока
public class UITimer : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    private Buffs _buffs;
    private RectTransform _rectTransform;
    private float _baseScale;

    private void Awake()
    {
        _buffs = Managers.GameObjects.GetObject("Player").GetComponent<Buffs>();
        _rectTransform = GetComponent<RectTransform>();
        _baseScale = _container.GetComponent<RectTransform>().sizeDelta.x;
    }

    private void FixedUpdate()
    {
        //Если модификатор получен, то в зависимосте от того где установлен компонент выводим информацию о времени баффа
        if(_buffs.PowerModificator > 1 || _buffs.SpeedModificator > 1)
        {
            switch(_container.name)
            {
                case ("Power bar"):
                    _rectTransform.sizeDelta = new Vector2((_buffs.PowerTimer / _buffs.BuffDuration) * _baseScale, _rectTransform.sizeDelta.y);
                    break;
                case ("Speed bar"):
                    _rectTransform.sizeDelta = new Vector2((_buffs.SpeedTimer / _buffs.BuffDuration) * _baseScale, _rectTransform.sizeDelta.y);
                    break;
            }
        }
    }
}
