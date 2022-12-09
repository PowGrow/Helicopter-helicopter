using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected EnemyBehavior Behavior;
    protected GameObject PlayerObject;
    protected IEnemyBehavior IEnemyBehavior;
    protected EnemyHealth Health;

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
        }
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
        if(IEnemyBehavior != null)
            IEnemyBehavior.Move(this.transform, PlayerObject.transform);
    }

    protected virtual void CheckCurrentBehavior(float value)
    {
        //Метод для переопределения, в базовом виде не делает ничего.
    }

    private void OnEnable()
    {
        Health.OnHealthCnaged += CheckCurrentBehavior;
    }

    private void OnDisable()
    {
        Health.OnHealthCnaged -= CheckCurrentBehavior;
    }

}
