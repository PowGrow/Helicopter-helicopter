using TMPro;
using UnityEngine;

//Класс работающий с объектом DescriptionTextObject, записывает в него текст описания выбранного компонента из JSON
public class UIPartsDescription : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI             _descriptionComponent;
    [SerializeField] private TextMeshProUGUI            _priceComponent;

    public void SetDescriptionText(string description)
    {
        //Устанавливаем значение текста в зависимости от выбранной части вертолёта и его идентификатора
        _descriptionComponent.text = description;
    }

    public void ClearDescriptionText()
    {
        //Очищаем описание
        _descriptionComponent.text = string.Empty;
    }

    public void SetPriceText(string price)
    {
        _priceComponent.text = price;
    }
}
