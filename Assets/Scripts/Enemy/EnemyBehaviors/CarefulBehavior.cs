using UnityEngine;

public class CarefulBehavior : BaseBehavior
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _chasingDistance = 7f;
    [SerializeField] private Transform _pendulumTransformLeft;
    [SerializeField] private Transform _pendulumTransformRight;

    private float _timer;
    private float _pendulumTime = 1f;

    public override void Move(Transform enemyTransform, Transform targetTransform)
    {
        PendulumMovement(enemyTransform, _pendulumTransformLeft.localPosition, _pendulumTransformRight.localPosition);
    }

    private void PendulumMovement(Transform enemyTransform, Vector2 leftPos, Vector2 rightPos)
    {
        if (_timer > _pendulumTime && _timer < _pendulumTime * 2)
            enemyTransform.localPosition = Vector2.MoveTowards(enemyTransform.localPosition, rightPos, Time.deltaTime * _speed);
        else if (_timer < _pendulumTime)
            enemyTransform.localPosition = Vector2.MoveTowards(enemyTransform.localPosition, rightPos, -1 * Time.deltaTime * _speed);
        else
            _timer = 0;
    }

    private void Start()
    {
        _timer = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }

}
