using UnityEngine;

public class BorderTransformAutoAdd : MonoBehaviour
{
    private void OnEnable()
    {
        Border.BorderCorrectionList.Add(this.transform);
    }

    private void OnDisable()
    {
        Border.BorderCorrectionList.Remove(this.transform);
    }
}
