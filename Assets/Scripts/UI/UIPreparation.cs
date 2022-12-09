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
    [SerializeField] private GameObject         _deployButton;
    [SerializeField] private GameObject         _previewPrefab;
    [SerializeField] private Transform          _partsPreviewButtonContainer; //Reference to parent object of all preview buttons
    [SerializeField] private Color              _chosenObjectColor;//Color of "Chosen" object
    [SerializeField] private Color              _defaultPreviewColor; //Default preview background color
    [SerializeField] private Color              _defaultObjectColor; //Default helicopter part color
    [SerializeField] private UIPartsDescription _partsDescription;
    [SerializeField] private TextMeshProUGUI    _gameSavedLabel;

    private float _previewOffset; //Horizontal offset for each preview button

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
    
    private void ClearPreviewButtons()  //Clearing all previous created preview buttons
    {
        if(PartsPreviewButtonParent.childCount > 0)
        {
            foreach (RectTransform child in PartsPreviewButtonParent)
            {
                Destroy(child.gameObject);
            }
        }
    }
    private PreviewButton CreatePreviewButton(GameObject buttonPrefab, float offset, int index, UnityEngine.Object part) //Creating preview button, setting it parent and position defined by its index
    {
        var previewButtonObject = Instantiate(buttonPrefab, PartsPreviewButtonParent, false);
        previewButtonObject.transform.localPosition = new Vector2((previewButtonObject.GetComponent<RectTransform>().sizeDelta.x + offset) * index, 0);
        var previewButton = previewButtonObject.GetComponent<PreviewButton>();
        previewButton.ItemPreviewImageSprite = part.GetType().GetField("Sprite").GetValue(part) as Sprite;
        previewButton.ItemPreviewName = part.GetType().GetField("Id").GetValue(part).ToString();
        return previewButton;
    }
    public List<Button> CreatePreviewButtons(string objectTag, IHelicopterPart selectedPart)
    {
        List<Button> buttonList = new List<Button>();
        var buttonCount = Utils.PartByTypeCount(objectTag);
        for(int buttonIndex = 0; buttonIndex < buttonCount; buttonIndex++)
        {
            var part = Resources.Load($"ScriptableObjects/{objectTag}/part_{buttonIndex}", Type.GetType(objectTag));
            var previewButton = CreatePreviewButton(_previewPrefab,_previewOffset,buttonIndex, part);
            if (Managers.Configuration.UnlockedObjects[objectTag][buttonIndex] == false)
                previewButton.IsLocked = true;
            buttonList.Add(previewButton.gameObject.GetComponent<Button>());
        }
        return buttonList;
    }
    private void SelectDraw(GameObject objectToSelect, GameObject previouslySelectedObject, int rendererType)//Color selected object and reseting color for previous selected object, rendererType 1: SpriteRenderer, 2:Image
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
        SelectDraw(objectToSelect, previouslySelectedObject, 1);
        return objectToSelect;
    }
    public void SelectPreviewButton(GameObject previewObject, IHelicopterPart selectedPart, GameObject selectedPreview) //Selecting preview button, calling its description and price from ScriptableObject container
    {
        SelectDraw(previewObject, selectedPreview, 2);
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
        _previewOffset = (float)Screen.width / (float)Screen.height; //Setting offset defined by screen ratio
    }
    private void OnEnable()
    {
        Managers.Configuration.OnClearSelection += ClearSelection;
        _preparationController.OnClearSelection += ClearSelection;
        _preparationController.OnCreatePreviewButtons += CreatePreviewButtons;
        _preparationController.OnSelectObject += SelectObject;
        _preparationController.OnSelectPreviewButton += SelectPreviewButton;
        _preparationController.OnSwitchingMainMenu += SwitchMainMenu;
        _mainMenuController.OnGameSaved += ShowSavedGameLabel;
    }
    private void OnDisable()
    {
        Managers.Configuration.OnClearSelection -= ClearSelection;
        _preparationController.OnClearSelection -= ClearSelection;
        _preparationController.OnCreatePreviewButtons -= CreatePreviewButtons;
        _preparationController.OnSelectObject -= SelectObject;
        _preparationController.OnSelectPreviewButton -= SelectPreviewButton;
        _preparationController.OnSwitchingMainMenu -= SwitchMainMenu;
        _mainMenuController.OnGameSaved -= ShowSavedGameLabel;
    }
}