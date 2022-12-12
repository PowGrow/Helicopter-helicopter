using UnityEngine;

public class EnemyAxisFollowing : BaseBehavior
{
    

    [SerializeField] private float _speed;


    private void Start()
    {
        var component = this.gameObject.GetComponent<SpriteRenderer>();
        component.color = Color.red;
    }
    public override void Move(Transform enemyTransform, Transform targetTransform)
    {
        Debug.Log("AxisFollowing работает");
            enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, new Vector2(targetTransform.position.x, enemyTransform.position.y),  Time.deltaTime * _speed);
        

    }

}
