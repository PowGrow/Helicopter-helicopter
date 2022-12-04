using TMPro;
using UnityEngine;

public class EnemySmartAss : MonoBehaviour
{
    private GameObject _playerObject;
    private EnemyBehavior _behavior;
    private IEnemyBehavior _enemyBehavior;
    private EnemyHealth _health;

    [Header("Preemptive angle")]
    [SerializeField]private float _offset = 0.1f;

    private void ChangeBehaviour(EnemyBehavior behavior)
    {
        _behavior = behavior;
        switch (_behavior)
        {
            case EnemyBehavior.active:
                _enemyBehavior = GetComponent<AggresiveBehavior>();
                break;
            case EnemyBehavior.defensive:
                this.transform.rotation = Quaternion.Euler(new Vector3(this.transform.rotation.x, this.transform.rotation.y, 180));
                _enemyBehavior = GetComponent<DefensiveBehavior>();
                break;
            case EnemyBehavior.careful:
                this.transform.rotation = Quaternion.Euler(new Vector3(this.transform.rotation.x, this.transform.rotation.y, 180));
                _enemyBehavior = GetComponent<CarefulBehavior>();
                break;
        }
    }
    private void Awake()
    {
        _health = GetComponent<EnemyHealth>();
    }

    private void Start()
    {
        _playerObject = Managers.GameObjects.GetObject("Player");
        ChangeBehaviour(EnemyBehavior.active);
    }

    private void FixedUpdate()
    {
        _enemyBehavior.Move(this.transform, _playerObject.transform);
    }

    private void OnEnable()
    {
        _health.OnHealthLowered += ChangeBehaviour;
    }

    private void OnDisable()
    {
        _health.OnHealthLowered -= ChangeBehaviour;
    }
}
