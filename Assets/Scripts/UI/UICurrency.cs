using TMPro;
using UnityEngine;

public class UICurrency : MonoBehaviour
{
    private TextMeshProUGUI _textLabel;

    private void SetCurrencyToTextLabel() //»змен€ет текстовое значение валюты после изменени€ переменной
    {
        _textLabel.text = Managers.Configuration.Currency.ToString();
    }
    private void Start()
    {
        _textLabel = GetComponent<TextMeshProUGUI>();
        SetCurrencyToTextLabel();
    }

    private void OnEnable() //ѕодпись на событие изменени€ количества валюты
    {
        Managers.Configuration.OnCurrencyChanged += SetCurrencyToTextLabel;
    }
    private void OnDisable()
    {
        Managers.Configuration.OnCurrencyChanged -= SetCurrencyToTextLabel;
    }
}
