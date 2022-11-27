using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPreparation : MonoBehaviour
{
    [SerializeField] private PreparationsController         _preparationController;
    [SerializeField] private MainMenuController             _mainMenuController;
    [SerializeField] private UIDescriptionContainer         _uiDescriptionContainer;//Объект контейнера описания объекта
    [SerializeField] private GameObject         _deployButton;//Кнопка начала миссии
    [SerializeField] private GameObject         _previewPrefab; //Префаб кнопок выбора компонентов вертолёта
    [SerializeField] private Transform          _partsPreviewButtonContainer; //Ссылка на родительский контейнер всех кнопок выбора компонентов вертолёта
    [SerializeField] private Color              _chosenObjectColor;//Цвет выбранного объекта
    [SerializeField] private Color              _defaultPreviewColor; //Стандартный цвет задника preview элемента
    [SerializeField] private Color              _defaultObjectColor; //Стандартный цвет элемента вертолёта
    [SerializeField] private UIPartsDescription _partsDescription;//Описание выбранного объекта
    [SerializeField] private TextMeshProUGUI    _gameSavedLabel;//Лейбл "Игра сохранена"

    private float                   _previewOffset; //Сдвиг по горизонтали для каждой кнопки предпосмотра элементов вертолёта

    public Transform PartsPreviewButtonParent
    {
        get { return _partsPreviewButtonContainer; }
    }
    public Color ChosenObjectColor
    {
        get { return _chosenObjectColor; }
    }
    public Color DefaultPreviewColor
    {
        get { return _defaultPreviewColor; }
    }
    public Color DefaultObjectColor
    {
        get { return _defaultObjectColor; }
    }
    
    private void ClearPreviewButtons()  //Удаляем все созданные ранее кнопки предпросмотра компонентов
    {
        if(PartsPreviewButtonParent.childCount > 0)
        {
            foreach (RectTransform child in PartsPreviewButtonParent)
            {
                Destroy(child.gameObject);
            }
        }
    }
    private PreviewButton CreatePreviewButton(GameObject buttonPrefab, float offset, int index, UnityEngine.Object part) //Создаём кнопку предпросмотра, устанавливаем ей нужную позицию в родительском объекте в зависимости от её номера
    {
        var previewButtonObject = Instantiate(buttonPrefab, PartsPreviewButtonParent, false); //Инициализируем
        previewButtonObject.transform.localPosition = new Vector2((previewButtonObject.GetComponent<RectTransform>().sizeDelta.x + offset) * index, 0); //Задаём позицию со смещением по индексу
        var previewButton = previewButtonObject.GetComponent<PreviewButton>();
        previewButton.ItemPreviewImageSprite = part.GetType().GetField("Sprite").GetValue(part) as Sprite; //Устанавливаем спрайт и имя
        previewButton.ItemPreviewName = part.GetType().GetField("Id").GetValue(part).ToString();
        return previewButton;
    }
    public List<Button> CreatePreviewButtons(string objectTag)
    {
        List<Button> buttonList = new List<Button>();
        var selectedObjectSprite = PreparationsController.SelectedHelicopterPart.Sprite;
        var buttonCount = Utils.ObjectCount(objectTag);
        
        for(int buttonIndex = 0; buttonIndex < buttonCount; buttonIndex++)
        {
            var part = Resources.Load($"ScriptableObjects/{objectTag}/part_{buttonIndex}", Type.GetType(objectTag));
            var previewButton = CreatePreviewButton(_previewPrefab,_previewOffset,buttonIndex, part);
            if (Managers.Configuration.UnlockedObjects[objectTag][buttonIndex] == false)
                previewButton.IsLocked = true;
            if (previewButton.ItemPreviewImageSprite.name == selectedObjectSprite.name)
                SelectPreviewButton(previewButton.gameObject);
            buttonList.Add(previewButton.gameObject.GetComponent<Button>());
        }
        return buttonList;
    }
    private void SelectDraw(GameObject objectToSelect, GameObject previouslySelectedObject, int rendererType)//Визуальная отрисовка изменения цвета вновь выбранного объекта, rendererType 1: SpriteRenderer, 2:Image
    {
        switch (rendererType)
        {
            case 1:
                if (previouslySelectedObject != null)
                    previouslySelectedObject.GetComponent<SpriteRenderer>().color = DefaultObjectColor;
                if (objectToSelect != null)
                    objectToSelect.GetComponent<SpriteRenderer>().color = ChosenObjectColor;
                break;
            case 2:
                if (previouslySelectedObject != null)
                    previouslySelectedObject.GetComponent<Image>().color = DefaultPreviewColor;
                if (objectToSelect != null)
                    objectToSelect.GetComponent<Image>().color = ChosenObjectColor;
                break;
        }
    }
    public GameObject SelectObject(GameObject objectToSelect,GameObject previouslySelectedObject)
    {
        SelectDraw(objectToSelect, previouslySelectedObject, 1); //Визуально выбираем новый объект
        return objectToSelect;
    }
    public void SelectPreviewButton(GameObject previewObject)
    {
        SelectDraw(previewObject, PreparationsController.SelectedPreview, 2);
        PreparationsController.SelectedPreview = previewObject;
        var selectedPart = PreparationsController.SelectedHelicopterPart;
        _partsDescription.SetDescriptionText(selectedPart.Description);
        _partsDescription.SetPriceText(selectedPart.Price.ToString());
        _deployButton.SetActive(false);
    }
    public void ClearSelection(GameObject selectedObject, int rendererType)
    {
        SelectDraw(null, selectedObject, rendererType);
        ClearPreviewButtons();
        _deployButton.SetActive(true);
    }
    public void SwitchMainMenu()
    {
        _mainMenuController.gameObject.SetActive(!_mainMenuController.gameObject.activeSelf);
    }
    public void ShowSavedGameLabel()
    {
        _gameSavedLabel.gameObject.SetActive(true);
        StartCoroutine(HideSaveGameLabel(2));
    }
    private IEnumerator HideSaveGameLabel(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        _gameSavedLabel.gameObject.SetActive(false);
        _gameSavedLabel.fontSize = 1;
    }

    private void Awake()
    {
        _previewOffset = (float)Screen.width / (float)Screen.height; //Устанавливаем значение отступа кнопок в зависимости размера экрана
    }

    private void OnEnable()
    {
        _preparationController.OnClearSelection += ClearSelection;
        _preparationController.OnCreatePreviewButtons += CreatePreviewButtons;
        _preparationController.OnSelectObject += SelectObject;
        _preparationController.OnSelectPreviewButton += SelectPreviewButton;
        _preparationController.OnSwitchingMainMenu += SwitchMainMenu;
        _mainMenuController.OnGameSaved += ShowSavedGameLabel;
    }

    private void OnDisable()
    {
        _preparationController.OnClearSelection -= ClearSelection;
        _preparationController.OnCreatePreviewButtons -= CreatePreviewButtons;
        _preparationController.OnSelectObject -= SelectObject;
        _preparationController.OnSelectPreviewButton -= SelectPreviewButton;
        _preparationController.OnSwitchingMainMenu -= SwitchMainMenu;
        _mainMenuController.OnGameSaved -= ShowSavedGameLabel;
    }
}
