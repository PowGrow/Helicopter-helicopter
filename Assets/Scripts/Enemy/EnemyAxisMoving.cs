using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAxisMoving : DroidEnemy
{ 
    [SerializeField]public Vector3 _movementDirection;
    [SerializeField]private int idDirecetion=1;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector3 basePosition;
    [SerializeField] public Vector3 endlessPosition;
    void Start()
    {
        Vector3 minPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)) + new Vector3(2,-2,0);
        Vector3 maxPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0, 0)) + new Vector3(0, 2, 0);
        Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)));
        endlessPosition = new Vector3(Random.Range(minPoint.x, 5f), Random.Range(minPoint.y, maxPoint.y), 0);
        _rb = this.GetComponent<Rigidbody2D>();
        basePosition = this.transform.position;
        _movementDirection = endlessPosition;
        if (endlessPosition.x < basePosition.x) idDirecetion = -1;
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {

        if(start) MoveByAxis();
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
    public new IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 2.3f));
            if (start)
            {

                GameObject missle = Instantiate(bulletPrefab);
                missle.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.5f);
                missle.GetComponent<EnemyFollow>().isEnemy = true;
                missle.GetComponent<EnemyFollow>().DamageMultiplier = damage;
            }
            Debug.Log("работает");
        }
    }
}
