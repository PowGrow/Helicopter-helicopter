using UnityEngine;

public interface IEnemyBehavior
{
    public void Move(Transform enemyTransform, Transform targetTransform);
}
