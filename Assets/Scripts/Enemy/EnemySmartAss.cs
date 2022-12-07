using UnityEngine;

[RequireComponent(typeof(AggresiveBehavior))]
[RequireComponent(typeof(CarefulBehavior))]
[RequireComponent(typeof(DefensiveBehavior))]
public class EnemySmartAss : EnemyBase
{
    protected override void CheckCurrentBehavior(float health)
    {
        if (health < base.Health.MaxHealth * 0.25)
            ChangeBehaviour(EnemyBehavior.defensive);
        else if (health < base.Health.MaxHealth * 0.5)
            ChangeBehaviour(EnemyBehavior.careful);
    }
    protected override void Start()
    {
        base.PlayerObject = Managers.GameObjects.GetObject("Player");
        ChangeBehaviour(EnemyBehavior.active);
    }
}
