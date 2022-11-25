using UnityEngine;

public class UIUnlockButton : MonoBehaviour
{
    public void UpdateUnlockState()
    {
        if (Managers.Configuration.UnlockedObjects[PreparationsController.SelectedHelicopterPart.Type][PreparationsController.SelectedHelicopterPart.Id])
            this.gameObject.SetActive(false);
        else
            this.gameObject.SetActive(true);
    }
}
