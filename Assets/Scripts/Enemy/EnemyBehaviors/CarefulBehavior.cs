using UnityEngine;

public class CarefulBehavior : BaseBehavior
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _chasingDistance = 7f;
    [SerializeField] private Transform _pendulumTransformLeft;
    [SerializeField] private Transform _pendulumTransformRight;

    private float _timer;
    private float _pendulumTime = 1f;
    private Rigidbody2D _targetRigidbody;
    private int _direction = 0;

    public override void Move(Transform enemyTransform, Transform targetTransform)
    {
        if (_targetRigidbody != null)
            LookAt2D(targetTransform, _targetRigidbody);
        PendulumMovement(enemyTransform, _pendulumTransformLeft.position, _pendulumTransformRight.position);
        var distance = Vector2.Distance(enemyTransform.position, targetTransform.position);
        if (Mathf.Abs(distance) > _chasingDistance)
            _direction = 1;
        else if (Mathf.Abs(distance) < _chasingDistance && Mathf.Abs(distance) > _chasingDistance - 1)
            _direction = 0;
        else _direction = -1;
        enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, targetTransform.position, _direction * Time.deltaTime * _speed);
    }

    private void PendulumMovement(Transform enemyTransform, Vector2 leftPos, Vector2 rightPos)
    {
        if (_timer > _pendulumTime && _timer < _pendulumTime * 2)
            enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, rightPos, Time.deltaTime * _speed);
        else if (_timer < _pendulumTime)
            enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, rightPos, -1 * Time.deltaTime * _speed);
        else
            _timer = 0;
    }
    private void Awake()
    {
        _targetRigidbody = Managers.GameObjects.GetObject("Player").GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _timer = 0;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }

}
