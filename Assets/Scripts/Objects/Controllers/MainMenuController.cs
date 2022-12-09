using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private TextMeshProUGUI _saveGameLabel;

    public Action OnGameSaved;
    public void OnNewGameButtonClick()
    {
        if(Managers.Levels.SceneId() != 1)
            Utils.TimeScale();
        Managers.Configuration.DefaultConfiguration();
        Managers.Levels.GoToNext();
    }

    public void OnContinueButtonClick()
    {
        if(Managers.Levels.SceneId() != 1)
            Utils.TimeScale();
        Managers.Data.LoadGameState();
        Managers.Levels.GoToNext();
    }

    private void CheckSave()
    {
        if (!Managers.Data.IsThereASave())
            _continueButton.interactable = false;
    }

    public void OnMainMenuButtonClick()
    {
        Utils.TimeScale();
        Managers.Levels.GoTo(1);
    }
    
    public void OnSaveGameButtonClick()
    {
        Managers.Data.SaveGameState();
        Utils.TimeScale();
        OnGameSaved?.Invoke();
        this.gameObject.SetActive(false);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void Awake()
    {
        if(Managers.Levels.SceneId() == 1)
            CheckSave();   
    }

}
