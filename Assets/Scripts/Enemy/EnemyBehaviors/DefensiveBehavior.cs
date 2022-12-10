using UnityEngine;

public class DefensiveBehavior : BaseBehavior
{
    [SerializeField] private float _speed;
    private float _horizontalBorder, _verticalBorder;
    private int _direction = 1;

    private const float BORDER_OFFSET = 0.5f;
    public override void Move(Transform enemyTransform, Transform targetTransform)
    {
        TryToChangeDirection(enemyTransform);
        enemyTransform.position = new Vector2(enemyTransform.position.x - Mathf.Sign(enemyTransform.position.x) * 0.1f, enemyTransform.position.y);//Offset to push enemy from border
        enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, new Vector2(_horizontalBorder, _verticalBorder), _direction * Time.deltaTime * _speed);
    }

    private void TryToChangeDirection(Transform enemyTransform)
    {
        if (enemyTransform.position.x >= _horizontalBorder)
            _direction = -1;

        if (enemyTransform.position.x <= (_horizontalBorder) * -1)
            _direction = 1;
    }

    private void Start()
    {
        _verticalBorder = Border.GetBorder("vertical") - BORDER_OFFSET;
        _horizontalBorder = Border.GetBorder("horizontal") - BORDER_OFFSET;
    }
}
