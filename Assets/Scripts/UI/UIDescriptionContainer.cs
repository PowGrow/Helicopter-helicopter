using UnityEngine;

public class UIDescriptionContainer : MonoBehaviour
{
    [SerializeField] private GameObject _descriptionContainer;
    [SerializeField] private GameObject _unlockButton;
    [SerializeField] private PreparationsController _preparationController;

    private void SetUnlockButtonState(bool state)
    {
        _unlockButton.SetActive(!state);
    }

    private void SwitchDescriptionContainer(bool state)
    {
        _descriptionContainer.SetActive(state);
    }

    private void OnEnable()
    {
        _preparationController.OnUnlockingPreview += SetUnlockButtonState;
        _preparationController.OnPartWasUnlocked += SetUnlockButtonState;
        _preparationController.OnSwitchingDescriptionContainer += SwitchDescriptionContainer;
    }

    private void OnDisable()
    {
        _preparationController.OnUnlockingPreview -= SetUnlockButtonState;
        _preparationController.OnPartWasUnlocked -= SetUnlockButtonState;
        _preparationController.OnSwitchingDescriptionContainer -= SwitchDescriptionContainer;
    }
}
