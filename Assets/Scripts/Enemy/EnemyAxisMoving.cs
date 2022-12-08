using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAxisMoving : DroidEnemy
{ 
    [SerializeField]public Vector3 _movementDirection;
    [SerializeField]public float _speed = 20f;
    [SerializeField]private int idDirecetion=1;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector3 basePosition;
    [SerializeField] public Vector3 endlessPosition;
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        basePosition = this.transform.position;
        _movementDirection = endlessPosition;
        if (endlessPosition.x < basePosition.x) idDirecetion = -1;
    }

    // Update is called once per frame
    void Update()
    {

        MoveByAxis();
    }
    void MoveByAxis()
    {
        Vector3 direction = (-this.transform.position +_movementDirection ).normalized;
        _rb.velocity = new Vector2(direction.x,direction.y) * _speed * Time.deltaTime;
        if (Mathf.Abs(transform.position.x - _movementDirection.x)<0.05f && Mathf.Abs(transform.position.y - _movementDirection.y)<0.05f)
        {
            if (idDirecetion == 1) _movementDirection = basePosition ;
            else _movementDirection = endlessPosition;
            idDirecetion *= -1;
        }

    }
    void OnDrawGizmosSelected()
    {

        Vector3 _gizmosDraw = endlessPosition;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_gizmosDraw, new Vector3(1, 1, 1));
    }
}
