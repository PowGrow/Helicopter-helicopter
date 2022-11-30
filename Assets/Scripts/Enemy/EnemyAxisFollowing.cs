using UnityEngine;

public class EnemyAxisFollowing : MonoBehaviour
{
    public GameObject player;
    public Vector3 movementDirection;
    public float speed;
    public int idDirecetion;
    void Start()
    {
        player = Managers.GameObjects.GetObject("Player");
        movementDirection = new Vector3(player.transform.position.x,this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
    void Update()
    {
        MoveByAxis();
    }
    void MoveByAxis()
    {
        movementDirection = new Vector3(player.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        if (!(Mathf.Abs(transform.position.x - player.transform.position.x) < 0.03f))
        {
            Vector3 direction = (movementDirection - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            Vector3 direction = new Vector3(0, 0, 0);
        }
    }
}
