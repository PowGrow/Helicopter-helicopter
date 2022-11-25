using System;
using UnityEngine;
using UnityEngine.UI;

public class PreviewButton : MonoBehaviour
{
    [SerializeField] private Image _previewButtonImage;
    [SerializeField] private GameObject _itemPreview;
    [SerializeField] private GameObject _lock;

    private UIPreparation _preparationUI;

    public Sprite ItemPreviewImageSprite
    {
        get { return _itemPreview.GetComponent<Image>().sprite; }
        set 
        {
            _itemPreview.GetComponent<Image>().sprite = value;
        }
    }
    public string ItemPreviewName
    {
        get { return this.transform.name; }
        set { this.transform.name = value; }
    }
    public Image PreviewButtonImage
    {
        get { return _previewButtonImage; }
    }
    public bool IsLocked
    {
        get { return _lock.activeSelf; }
        set { _lock.SetActive(value); }
    }
    private int Id
    {
        get { return Convert.ToInt32(this.ItemPreviewName); }
    }

    public void OnPreviewButtonClick() //Выполняется при выборе одной из частей вертолёта, что бы заменить текущую часть
    {
        if (PreparationsController.SelectedObjectPrevious != -1
            && !Managers.Configuration.UnlockedObjects[PreparationsController.SelectedHelicopterPart.Type][PreparationsController.SelectedHelicopterPart.Id]) //Если при выборе нового объекта текущий не был куплен то возвращаем сперва конфигурацию на предыдущую
            Select(PreparationsController.SelectedObjectPrevious);
        Select(Id);
    }

    public void Select(int id)
    {
        GameObject selectedObject = PreparationsController.Instance.ChangePart(id); //В зависимости от типа выбранного ранее объекта выполняем замену нужной части
        if (selectedObject != null) _preparationUI.SelectObject(selectedObject, null); //Окрашивает предыдущий выбранный элемент в стандартный цвет, а ново-выбранный в цвет "выбранного компонента"
        _preparationUI.SelectPreviewButton(this.gameObject);
    }

    public void RemoveLock()
    {
        if(IsLocked)
            _lock.SetActive(false);
    }

    private void Start()
    {
        _preparationUI = UIPreparation.Instance;
    }
}
