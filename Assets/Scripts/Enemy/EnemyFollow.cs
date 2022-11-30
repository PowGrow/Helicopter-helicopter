using System.Collections;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _offset;
    [SerializeField] private float _speed = 1;

    private IHealth _playerHealth;
    private IHealth _health;

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
        _health.GetDamage(100);
        _playerHealth.GetDamage(10);
    }

    void Awake()
    {
        _health = GetComponent<IHealth>();
        _player = Managers.GameObjects.GetObject("Player");
        _playerHealth = _player.GetComponent<IHealth>();
    }
    private void OnEnable()
    {
        StartCoroutine(DestroyByTime());
    }
}
