using UnityEngine;

public class UIDescriptionContainer : MonoBehaviour
{
    [SerializeField] private GameObject _unlockButton;
    [SerializeField] private PreparationsController _preparationController;

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

    private void SetUnlockButtonState(bool state)
    {
        _unlockButton.SetActive(state);
    }

    private void OnEnable()
    {
        _preparationController.OnUnlockingPreview += SetUnlockButtonState;
    }

    private void OnDisable()
    {
        _preparationController.OnUnlockingPreview -= SetUnlockButtonState;
    }
}
