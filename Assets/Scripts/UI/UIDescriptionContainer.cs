using UnityEngine;

public class UIDescriptionContainer : MonoBehaviour
{
    [SerializeField] private GameObject _unlockButton;
    private UIDescriptionContainer _uiDescriptionContainer;

    public UIDescriptionContainer UiDescriptionContainer
    {
        get { return _uiDescriptionContainer; }
    }

    public GameObject GameObject
    {
        get { return this.gameObject; }
    }

    public bool UnlockButton
    {
        get { return _unlockButton.activeSelf; }
        set 
        { _unlockButton.SetActive(value); }
    }

    private void ChangeUnlockButtonState()
    {

    }

    private void OnEnable()
    {
        _uiDescriptionContainer = GetComponent<UIDescriptionContainer>();
    }
}
