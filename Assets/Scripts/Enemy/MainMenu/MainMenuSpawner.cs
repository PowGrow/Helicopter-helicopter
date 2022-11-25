using System.Collections.Generic;
using UnityEngine;

public class MainMenuSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyList;

    public void SpawnEnemy()
    {
        var enemyToSpawn = Random.Range(0, _enemyList.Count);
        Instantiate(_enemyList[enemyToSpawn]);
    }

    private void Start()
    {
        SpawnEnemy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        SpawnEnemy();
    }
}
