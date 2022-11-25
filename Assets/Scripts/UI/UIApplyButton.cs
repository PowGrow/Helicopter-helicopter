using UnityEngine;

public class UIApplyButton : MonoBehaviour
{
    private UIPreparation _uiPreparationInstace;

    public void OnApplyButtonClick()
    {
        //_uiPreparationInstace.OnPreviewButtonClick();
    }
    private void OnEnable()
    {
        _uiPreparationInstace = UIPreparation.Instance;
    }
}
