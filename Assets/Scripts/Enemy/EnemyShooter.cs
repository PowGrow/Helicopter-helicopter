using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private IShooter _enemyGun;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private LayerMask _shootingTargetLayer;
    private RaycastHit2D _rayCastHit2D;
    private ContactFilter2D _filter;
    private Vector2 _direction;

    private void Awake()
    {
        _enemyGun = GetComponent<IShooter>();
        _filter.SetLayerMask(_shootingTargetLayer);
    }

    private void FixedUpdate()
    {
        _direction = (Vector2)transform.TransformDirection(Vector2.up);
        _rayCastHit2D = Physics2D.Raycast((Vector2)_shootingPoint.position, _direction, Mathf.Infinity, _filter.layerMask);
        if (_rayCastHit2D.collider != null)
            _enemyGun.Fire();
    }
}
