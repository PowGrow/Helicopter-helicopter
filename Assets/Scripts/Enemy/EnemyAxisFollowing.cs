using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAxisFollowing : DroidEnemy
{
    
    [SerializeField]private GameObject _player;
    [SerializeField]private Vector3 _movementDirection;
    [SerializeField]public float _speed = 20;
    [SerializeField]private int idDirecetion;
    [SerializeField] Rigidbody2D _rb;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _movementDirection = new Vector3(_player.transform.position.x,this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        _rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        MoveByAxis();
    }
    void MoveByAxis()
    {
        _movementDirection = new Vector3(_player.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        if (!(Mathf.Abs(transform.position.x - _player.transform.position.x) < 0.03f))
        {
            Vector3 direction = (_movementDirection - transform.position).normalized;
            _rb.velocity = new Vector2(direction.x, 0) * _speed * Time.deltaTime;
        }
        else
        {
            _rb.velocity = new Vector2(0, 0);
        }
        
       
        
    }
    void OnDrawGizmosSelected()
    {

    }
}
