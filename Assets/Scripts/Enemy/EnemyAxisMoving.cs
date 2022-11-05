using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAxisMoving : MonoBehaviour
{ 
    [SerializeField]private Vector3 _movementDirection;
    [SerializeField]private float _speed;
    [SerializeField]private int idDirecetion;
    [SerializeField] private Rigidbody2D _rb;
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        MoveByAxis();
    }
    void MoveByAxis()
    {
        Debug.Log(idDirecetion);
        Vector3 direction = (_movementDirection - transform.position).normalized;
        _rb.velocity = new Vector2(direction.x, 0) * _speed * Time.deltaTime;
        if (Mathf.Abs(transform.position.x - _movementDirection.x)<0.05f)
        {
            _movementDirection *= -1;
        }

    }
    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Vector3 _gizmosDrawLeft = new Vector3(transform.position.x- _movementDirection.x, _movementDirection.y, _movementDirection.z);
        Gizmos.DrawWireCube(_gizmosDrawLeft, new Vector3(1, 1, 1));
        Vector3 _gizmosDraw = new Vector3(transform.position.x + _movementDirection.x, _movementDirection.y, _movementDirection.z);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_gizmosDraw, new Vector3(1, 1, 1));
    }
}
