using System;
using UnityEngine;

public class Border : MonoBehaviour
{
    private const float SHIP_BORDER_OFFSET_VERTICAL = 0f;
    private const float SHIP_BORDER_OFFSET_HORIZONTAL = 3f;

    private float _borderHorizontal, _borderVertical;
    private GameObject _player;

    public Vector2 GetBorderds()
    {
        return new Vector2(_borderHorizontal, _borderVertical);
    }

    private float BorderPositionCorrection(float playerPosition, float border, float borderOffset)
    {
        float newPlayerPosition = playerPosition;
        if (Math.Abs(playerPosition) > border - borderOffset)
        {
            int direction = 1;
            if (playerPosition < 0)
                direction = -1;
            newPlayerPosition = direction * (border - borderOffset);
        }
        return newPlayerPosition;
    }

    private void Awake()
    {
        _borderVertical = Camera.main.orthographicSize;
        _borderHorizontal = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
    }
    private void Start()
    {
        _player = Managers.GameObjects.GetObject("Player");
    }

    private void LateUpdate()
    {
        _player.transform.position = new Vector2(BorderPositionCorrection(_player.transform.position.x, _borderHorizontal, SHIP_BORDER_OFFSET_HORIZONTAL),
                                                 BorderPositionCorrection(_player.transform.position.y, _borderVertical, SHIP_BORDER_OFFSET_VERTICAL));
    }
}
