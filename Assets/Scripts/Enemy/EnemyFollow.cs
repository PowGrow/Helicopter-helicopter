using System.Collections;
using UnityEngine;

public class EnemyFollow : DroidEnemy
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _offset;
    [SerializeField] private float _speed = 1;

    private Health _playerHealth;

    void EnemyMove()//Движкние к игроку
    {
        transform.position = Vector2.MoveTowards(this.transform.position, _player.transform.position, Time.deltaTime * _speed);
    }
    void LookAtPlayer()//Постоянный поворот на игрока
    {
        Vector2 direction = this.transform.position - _player.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + _offset);
    }

    private IEnumerator DestroyByTime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
    void Update()
    {
        LookAtPlayer();
        EnemyMove();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //пока не доделано
        GetDamage(100);
        _playerHealth.GetDamage(10);
    }

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerHealth = _player.GetComponent<Health>();
    }
    private void OnEnable()
    {
        StartCoroutine(DestroyByTime());
    }
}
