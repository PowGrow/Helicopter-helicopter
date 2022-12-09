using UnityEngine;

public class AggresiveBehavior : BaseBehavior
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _chasingDistance = 1f;
    private int _direction;
    private Rigidbody2D _targetRigidbody;

    public override void Move(Transform enemyTransform, Transform targetTransform) //Преследуем цель до определённой дистанции
    {
        if(_targetRigidbody != null)
            LookAt2D(targetTransform, _targetRigidbody);
        var distance = Vector2.Distance(enemyTransform.position, targetTransform.position);
        if (Mathf.Abs(distance) > _chasingDistance)
            _direction = 1;
        else if (Mathf.Abs(distance) < _chasingDistance && Mathf.Abs(distance) > _chasingDistance - 1)
            _direction = 0;
        else _direction = -1;
        enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, targetTransform.position, _direction * Time.deltaTime * _speed);
    }
    private void Awake()
    {
        _targetRigidbody = Managers.GameObjects.GetObject("Player").GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _direction = 0;
    }
}
