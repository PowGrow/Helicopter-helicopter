using UnityEngine;

public abstract class BaseBehavior : MonoBehaviour, IEnemyBehavior
{
    [Header("Preemptive angle")]
    [SerializeField] private float _offset = 0.1f;

    public abstract void Move(Transform enemyTransform, Transform targetTransform);

    protected void LookAt2D(Transform targetTransform,Rigidbody2D targetRigidbody)
    {
        Vector2 direction = (Vector2)(targetTransform.position - transform.position).normalized;
        var angle = Mathf.Atan2(direction.y + PreemptiveAngle(targetRigidbody.velocity.y, targetRigidbody), direction.x + PreemptiveAngle(targetRigidbody.velocity.x, targetRigidbody)) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle - 90f));
    }

    private float PreemptiveAngle(float velocity, Rigidbody2D targetRigidbody)
    {
        if (velocity != 0)
            return Mathf.Sign(targetRigidbody.velocity.y) * _offset;
        return 0;
    }
}
