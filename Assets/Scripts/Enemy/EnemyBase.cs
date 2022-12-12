using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected EnemyBehavior Behavior;
    [SerializeField] private EnemyAnimator _animator;
    protected GameObject PlayerObject;
    protected IEnemyBehavior IEnemyBehavior;
    protected EnemyHealth Health;
    private bool IsActive = false;

    private void EnemyArrived(bool state)
    {
        IsActive = state;
    }
    private SpriteRenderer HideEnemy()
    {
        return gameObject.GetComponent<SpriteRenderer>();
    }
    public void ChangeBehaviour(EnemyBehavior behavior)
    {
        switch (behavior)
        {
            case EnemyBehavior.active:
                IEnemyBehavior = GetComponent<AggresiveBehavior>();
                break;
            case EnemyBehavior.defensive:
                IEnemyBehavior = GetComponent<DefensiveBehavior>();
                break;
            case EnemyBehavior.careful:
                IEnemyBehavior = GetComponent<CarefulBehavior>();
                break;
            case EnemyBehavior.following:
                IEnemyBehavior = GetComponent<EnemyAxisFollowing>();
                break;
            case EnemyBehavior.axismoving:
                IEnemyBehavior = GetComponent<EnemyAxisMoving>();
                break;
            case EnemyBehavior.followingcircle:
                IEnemyBehavior = GetComponent<EnemyAxisFollowingCircle>();
                break;
        }
    }
    protected virtual void CheckCurrentBehavior(float value)
    {
        //Method for overriding, base do nothing...
    }
    private void Awake()
    {
        Health = GetComponent<EnemyHealth>();
    }

    protected virtual void Start()
    {
        PlayerObject = Managers.GameObjects.GetObject("Player");
        
    }

    private void FixedUpdate()
    {
        if(IEnemyBehavior != null && IsActive)
            IEnemyBehavior.Move(this.transform, PlayerObject.transform);
    }

    private void OnEnable()
    {
        Health.OnHealthCnaged += CheckCurrentBehavior;
        _animator.OnEnemyArrival += EnemyArrived;
        _animator.IsEnemyDestroyed += HideEnemy;
    }

    private void OnDisable()
    {
        Health.OnHealthCnaged -= CheckCurrentBehavior;
        _animator.OnEnemyArrival -= EnemyArrived;
        _animator.IsEnemyDestroyed += HideEnemy;
    }
}
