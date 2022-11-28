using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAxisMoving : DroidEnemy
{ 
    [SerializeField]public Vector3 _movementDirection;
    [SerializeField]private float _speed = 15f;
    [SerializeField]private int idDirecetion=1;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector3 basePosition;
    [SerializeField] private Vector3 endlessPosition;
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        basePosition = this.transform.position;
        endlessPosition = basePosition + _movementDirection;
    }

    // Update is called once per frame
    void Update()
    {

        MoveByAxis();
    }
    void MoveByAxis()
    {
        Vector3 direction = (endlessPosition - basePosition).normalized;
        _rb.velocity = new Vector2(idDirecetion, 0) * _speed * Time.deltaTime;
        if (Mathf.Abs(transform.position.x - endlessPosition.x)<0.05f)
        {
            if (idDirecetion == 1) endlessPosition = basePosition - _movementDirection;
            else endlessPosition = basePosition + _movementDirection;
            idDirecetion *= -1;
        }

    }
    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Vector3 _gizmosDrawLeft = new Vector3(basePosition.x- _movementDirection.x, _movementDirection.y, _movementDirection.z);
        Gizmos.DrawWireCube(_gizmosDrawLeft, new Vector3(1, 1, 1));
        Vector3 _gizmosDraw = new Vector3(basePosition.x + _movementDirection.x, _movementDirection.y, _movementDirection.z);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_gizmosDraw, new Vector3(1, 1, 1));
    }
}
