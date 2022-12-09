using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreparationsController : MonoBehaviour
{
    [SerializeField] private PreparationData _preparationData;
    private PlayerControls _playerControls; //Экземпрял класса input action "PlayerControls"
    private RaycastHit2D _screenHit; //Точка клика по экрану
    private List<Button> PreviewButtonList;


    public Func<string, IHelicopterPart, List<Button>>      OnCreatePreviewButtons;
    public Action<bool>                                     OnUnlockingPreview;
    public Func<GameObject, GameObject, GameObject>         OnSelectObject;
    public Action<GameObject,IHelicopterPart,GameObject>    OnSelectPreviewButton;
    public Action                                           OnSwitchingMainMenu;
    public Action<bool>                                     OnPartWasUnlocked;
    public Action<bool>                                     OnSwitchingDescriptionContainer;
    public Action<GameObject, int>                          OnClearSelection;

    private void OnScreenClick(Vector3 mousePosition) //Вызывается при клике на экран
    {
        //Если при клике попадается коллайдер, то окрашиваем ранее выбранный объект в "стандартный" цвет, если он есть и выбираем новый объект
        //окрашивая его в цвет "выбранной части вертолёта"
        _screenHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero);

        if (_screenHit.collider != null)
        {
            OnClearSelection?.Invoke(_preparationData.SelectedObject, 1);
            OnClearSelection.Invoke(_preparationData.SelectedPreview, 2);
            OnSwitchingDescriptionContainer?.Invoke(true);
            OnUnlockingPreview?.Invoke(true);
            ResetSelectionToBoughtPart();
            _preparationData.SelectedObject = OnSelectObject.Invoke(_screenHit.collider.gameObject, _preparationData.SelectedObject);
            PreviewButtonList = OnCreatePreviewButtons.Invoke(_preparationData.SelectedHelicopterPart.Type, _preparationData.SelectedHelicopterPart);
            for(int index = 0; index < PreviewButtonList.Count; index++)
            {
                var buttonIndex = index;
                PreviewButtonList[index].onClick.AddListener(() => OnPreviewButtonClick(buttonIndex));
                if (Convert.ToInt32(PreviewButtonList[index].gameObject.name) == _preparationData.SelectedHelicopterPart.Id)
                {
                    OnSelectPreviewButton.Invoke(PreviewButtonList[index].gameObject, _preparationData.SelectedHelicopterPart, _preparationData.SelectedPreview);
                    _preparationData.SelectedPreview = PreviewButtonList[index].gameObject;
                }
            }
        }
    }
    private void OnPreviewButtonClick(int index) //Выполняется при выборе одной из частей вертолёта, что бы заменить текущую часть
    {
        if (_preparationData.SelectedObjectPrevious != -1
            && !Managers.Configuration.UnlockedObjects[_preparationData.SelectedHelicopterPart.Type][_preparationData.SelectedHelicopterPart.Id]) //Если при выборе нового объекта текущий не был куплен то возвращаем сперва конфигурацию на предыдущую
            SelectPart(_preparationData.SelectedObjectPrevious);
        SelectPart(index);

        void SelectPart(int partIndex)
        {
            var newSelectedObject = _preparationData.ChangePart(partIndex);
            if (newSelectedObject != null)
                _preparationData.SelectedObject = OnSelectObject.Invoke(newSelectedObject, _preparationData.SelectedObject);
            OnSelectPreviewButton.Invoke(PreviewButtonList[partIndex].gameObject, _preparationData.SelectedHelicopterPart, _preparationData.SelectedPreview);
            _preparationData.SelectedPreview = PreviewButtonList[partIndex].gameObject;
            OnSwitchingDescriptionContainer.Invoke(true);
            OnPartWasUnlocked.Invoke(Managers.Configuration.UnlockedObjects[_preparationData.SelectedHelicopterPart.Type][_preparationData.SelectedHelicopterPart.Id]);
        }
    }
    public void DeployButtonClick() //Вызывается при клике на кнопку "Deploy" совершается переход на следующую сцену "Game"
    {
        Managers.Configuration.HelicopterData = Managers.Data.GetHelicopterData(Managers.GameObjects.GetObject("Player"));
        Time.timeScale = 1;
        Managers.Levels.GoToNext();
    }
    public void UnlockButtonClick() //Вызывается при клике на кнопку unlock, для покупки новой части вертолёта
    {
        if(_preparationData.SelectedHelicopterPart.Price <= Managers.Configuration.Currency)
        {
            Managers.Configuration.Currency -= _preparationData.SelectedHelicopterPart.Price;
            Managers.Configuration.UnlockedObjects[_preparationData.SelectedHelicopterPart.Type][_preparationData.SelectedHelicopterPart.Id] = true;
            _preparationData.SelectedPreview.GetComponent<PreviewButton>().RemoveLock();
            OnUnlockingPreview.Invoke(true);//Передаём true- если хотим убрать кнопку Unlock
        }
    }
    private void EscapeButtonPressed() //При нажатии кнопки Escape, выходит из выбора компонентов
    {
        ResetSelectionToBoughtPart();
        if (_preparationData.SelectedObject == null)
        {
            OnSwitchingMainMenu.Invoke();
            Utils.TimeScale();
        }
        OnClearSelection.Invoke(_preparationData.SelectedObject, 1);
        OnSwitchingDescriptionContainer.Invoke(false);
        _preparationData.SelectedObject = null;
    }
    public void ResetSelectionToBoughtPart() //Метод сбрасывающий выбор компонента на предыдущий разблокированный, в случае если новый выбраный не был куплен
    {
        if (_preparationData.SelectedObject != null)
        {
            if (!Managers.Configuration.UnlockedObjects[_preparationData.SelectedHelicopterPart.Type][_preparationData.SelectedHelicopterPart.Id])
                _preparationData.ChangePart(_preparationData.SelectedObjectPrevious);
        }
    }
    private void Awake()
    {
        _playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        _playerControls.Player.Mouse.performed += callbackContext => OnScreenClick(Input.mousePosition);
        _playerControls.GUI.Escape.performed += callbackContext => EscapeButtonPressed();
        _playerControls.Enable();
}
    private void OnDisable()
    {
        _playerControls.Disable();
    }
}