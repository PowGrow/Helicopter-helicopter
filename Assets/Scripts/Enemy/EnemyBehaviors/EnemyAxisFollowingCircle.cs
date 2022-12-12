using UnityEngine;

public class EnemyAxisFollowingCircle : BaseBehavior
{

    [SerializeField] private float _speed;
    [SerializeField] private float _rotation;
    [SerializeField] private float y;

    private void Start()
    {
        y = this.transform.position.y;
        var component = this.gameObject.GetComponent<SpriteRenderer>();
        component.color = Color.red;
    }
       
    public override void Move(Transform enemyTransform, Transform targetTransform)
    {
        Debug.Log("AxisCircle работает");
        y += Random.Range(-0.5f, 0.5f);
        enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, new Vector2(targetTransform.position.x + Mathf.Cos(_rotation * Mathf.PI / 180f), y + Mathf.Sin(_rotation * Mathf.PI / 180f)), Time.deltaTime * _speed);
       _rotation += 360 * Time.deltaTime;
    }
}
