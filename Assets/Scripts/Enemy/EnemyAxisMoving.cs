using UnityEngine;

public class EnemyAxisMoving : MonoBehaviour
{
    public Vector3 firstDirection;
    public Vector3 secondDirection;
    public Vector3 movementDirection;
    public float speed;
    public int idDirecetion;
    void Start()
    {
        movementDirection = firstDirection;
    }

    // Update is called once per frame
    void Update()
    {
        MoveByAxis();
    }
    void MoveByAxis()
    {
        Vector3 direction = (movementDirection - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        if (idDirecetion == 1 && transform.position.x < movementDirection.x)
        {
            idDirecetion = -1;
            movementDirection = secondDirection;
        }
        if (idDirecetion == -1 && transform.position.x > movementDirection.x)
        {
            idDirecetion = 1;
            movementDirection = firstDirection;
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(firstDirection, new Vector3(1, 1, 1));
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(secondDirection, new Vector3(1, 1, 1));
    }
}
