using UnityEngine;

public class UIUnlockButton : MonoBehaviour
{
    [SerializeField] private PreparationData _preparationData;
    public void UpdateUnlockState() //If object unlocked in UnlockedObjects list hiding unlock button
    {
        if (Managers.Configuration.UnlockedObjects[_preparationData.SelectedHelicopterPart.Type][_preparationData.SelectedHelicopterPart.Id])
            this.gameObject.SetActive(false);
        else
            this.gameObject.SetActive(true);
    }
}
