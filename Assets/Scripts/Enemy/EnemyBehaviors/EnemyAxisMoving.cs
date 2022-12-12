using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAxisMoving : BaseBehavior
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 _movementDirection;
    [SerializeField] private float _speed;
    private float horizontalBorder;
    private float verticalBorder;
    void Start()
    {
        horizontalBorder = Border.GetBorder("horizontal");
        verticalBorder = Border.GetBorder("vertical");
        _movementDirection = ChangeDirection(horizontalBorder, verticalBorder);
    }

    // Update is called once per frame
    public override void Move(Transform enemyTransform, Transform targetTransform)
    {
        enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, _movementDirection , _speed * Time.deltaTime);
        if (Mathf.Abs(enemyTransform.position.x - _movementDirection.x) < 0.05f && Mathf.Abs(enemyTransform.position.y - _movementDirection.y) < 0.05f)
        {
            _movementDirection = ChangeDirection(horizontalBorder,verticalBorder);
        }              
    }
    private Vector3 ChangeDirection(float x,float y)
    {
        return new Vector3(Random.Range(-x, x), Random.Range(0f, y), 0);
    }
}
