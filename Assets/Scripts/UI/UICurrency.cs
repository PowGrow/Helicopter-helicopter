using TMPro;
using UnityEngine;

//Currency value visualization
public class UICurrency : MonoBehaviour
{
    private TextMeshProUGUI _textLabel;

    private void SetCurrencyToTextLabel()
    {
        _textLabel.text = Managers.Configuration.Currency.ToString();
    }
    private void Start()
    {
        _textLabel = GetComponent<TextMeshProUGUI>();
        SetCurrencyToTextLabel();
    }

    private void OnEnable()
    {
        Managers.Configuration.OnCurrencyChanged += SetCurrencyToTextLabel;
    }
    private void OnDisable()
    {
        Managers.Configuration.OnCurrencyChanged -= SetCurrencyToTextLabel;
    }
}
