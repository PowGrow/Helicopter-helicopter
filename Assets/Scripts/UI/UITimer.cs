using UnityEngine;

public class UITimer : MonoBehaviour //Class attached to timer bar showing last buff duration time
{
    [SerializeField] private GameObject _container;
    private Buffs _buffs;
    private RectTransform _rectTransform;
    private float _baseBarWidth;

    private const float DEFAULT_MODIFICATOR_VALUE = 1f;

    private void Awake()
    {
        _buffs = Managers.GameObjects.GetObject("Player").GetComponent<Buffs>();
        _rectTransform = GetComponent<RectTransform>();
        _baseBarWidth = _container.GetComponent<RectTransform>().sizeDelta.x;
    }

    private void FixedUpdate()
    {
        if(_buffs.PowerModificator > DEFAULT_MODIFICATOR_VALUE || _buffs.SpeedModificator > DEFAULT_MODIFICATOR_VALUE)
        {
            switch(_container.name)
            {
                case ("Power bar"):
                    _rectTransform.sizeDelta = new Vector2((_buffs.PowerTimer / _buffs.BuffDuration) * _baseBarWidth, _rectTransform.sizeDelta.y);
                    break;
                case ("Speed bar"):
                    _rectTransform.sizeDelta = new Vector2((_buffs.SpeedTimer / _buffs.BuffDuration) * _baseBarWidth, _rectTransform.sizeDelta.y);
                    break;
            }
        }
    }
}
