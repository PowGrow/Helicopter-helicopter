using System;
using System.Collections.Generic;
using UnityEngine;

//Class setting border by screen size
public class Border : MonoBehaviour
{
    private const float SHIP_BORDER_OFFSET_VERTICAL = 1f;
    private const float SHIP_BORDER_OFFSET_HORIZONTAL = 3f;

    private static float _borderHorizontal, _borderVertical;
    private static List<Transform> _borderCorrectionList = new List<Transform>();

    public static List<Transform> BorderCorrectionList
    {
        get { return _borderCorrectionList; }
        set { _borderCorrectionList = value; }
    }
    public static float GetBorder(string axis)
    {
        switch (axis)
        {
            case "horizontal":
                return _borderHorizontal - SHIP_BORDER_OFFSET_HORIZONTAL;
            case "vertical":
                return _borderVertical - SHIP_BORDER_OFFSET_VERTICAL;
            default:
                throw new NotSupportedException();
        }
    }
    private float BorderPositionCorrection(float transformPosition, float border, float borderOffset)
    {
        var correctedTransformPosition = transformPosition;
        if (Math.Abs(transformPosition) > border - borderOffset)
        {
            correctedTransformPosition = Mathf.Sign(transformPosition) * (border - borderOffset);
            Debug.Log($"Corrected position: {transformPosition} to {border}");
        }

        return correctedTransformPosition;
    }

    private void Awake()
    {
        var mainCam = Camera.main;
        _borderVertical = mainCam.orthographicSize;
        _borderHorizontal = mainCam.orthographicSize * ((float)Screen.width / (float)Screen.height);
    }
    private void LateUpdate()
    {
        foreach(Transform transform in _borderCorrectionList) 
        {
            transform.position = new Vector2(BorderPositionCorrection(transform.position.x, _borderHorizontal, SHIP_BORDER_OFFSET_HORIZONTAL),
                                                 BorderPositionCorrection(transform.position.y, _borderVertical, SHIP_BORDER_OFFSET_VERTICAL));
        }
    }
}
