using UnityEngine;

//Class must be attached to any transform who should be controll by Border rules
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
