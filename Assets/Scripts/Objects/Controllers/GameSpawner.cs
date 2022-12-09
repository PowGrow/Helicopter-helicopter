using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    [SerializeField] private int _totalEnemyCount;
    [SerializeField] private int _enemyOnScreen;
    [SerializeField] private int _spawnTimeDelay;
    [SerializeField] private List<GameObject> _enemyTypeList;
    [SerializeField] private GameObject _enemyBehaviorContainerObject;
    [SerializeField] private TextMeshProUGUI _returningLabel;

    private List<IEnemyBehavior> _enemyBehaviorList;
    private List<float> _spawnPointsList;
    private List<GameObject> _enemies;
    private float _verticalBorder;
    private float _verticalOffset = 1.5f;
    private float _horizontalBorder;
    private float _spawnedEnemyCount = 0;
    public float SpawnedEnemyCount
    {
        get { return _spawnedEnemyCount; }
        set { _spawnedEnemyCount = value; }
    }

    private void RemoveEnemy(GameObject enemyGameObject)
    {
        foreach(GameObject enemie in _enemies.ToList())
        {
            if (enemie.GetInstanceID() == enemyGameObject.GetInstanceID())
                _enemies.Remove(enemie);
        }
        var health = enemyGameObject.GetComponent<EnemyHealth>();
        health.OnEnemyDying -= RemoveEnemy;
        if(_spawnedEnemyCount < _totalEnemyCount)
            StartCoroutine(SpawnOverTime(_spawnTimeDelay));
        if (_spawnedEnemyCount >= _totalEnemyCount && _enemies.Count() == 0)
            StartCoroutine(ReturnToBase());

    }

    private List<float> GetSpawnPoints(float screenWidth, float enemyOnScreen)
    {
        var spawnPoints = new List<float>();
        var spawnPointOffset = (screenWidth / enemyOnScreen) / 2;
        var spawnPoint = spawnPointOffset;
        for (int index = 0; index < enemyOnScreen; index++)
        {
            spawnPoints.Add(spawnPoint);
            spawnPoint += spawnPointOffset * 2;
        }
        return spawnPoints;
    }

    private void SpawnEnemy(float spawnPoint)
    {
        var rnd = Random.Range(0, _enemyTypeList.Count());
        var enemyType = _enemyTypeList[rnd];
        var enemy = Instantiate(enemyType, new Vector3(spawnPoint, _verticalBorder, 0), Quaternion.Euler(new Vector3(0,0,180)));
        var health = enemy.gameObject.GetComponent<EnemyHealth>();
        health.OnEnemyDying += RemoveEnemy;
        SetRandomEnemiPersonality(enemy);
        _enemies.Add(enemy);
        _spawnedEnemyCount++;
    }

    private IEnumerator SpawnOverTime(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        if (_enemies.Count() < _enemyOnScreen)
            SpawnEnemy(_spawnPointsList[Random.Range(0, _enemyOnScreen)]);
        
    }

    private IEnumerator ReturnToBase()
    {
        _returningLabel.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        _returningLabel.gameObject.SetActive(false);
        _returningLabel.fontSize = 1;
        Managers.Levels.GoToPrevious();
    }

    private void SetRandomEnemiPersonality(GameObject enemy)
    {
        switch (Random.Range(0, 6))
        {
            case 0:
                var smartAss = enemy.GetComponent<EnemySmartAss>();
                smartAss.enabled = true;
                foreach (IEnemyBehavior enemyBehavior in _enemyBehaviorList)
                {
                    var component = enemy.GetComponent(enemyBehavior.GetType()) as Behaviour;
                    component.enabled = true;
                }
                break;
            default:
                var baseDude = enemy.GetComponent<EnemyBase>();
                EnemyBehavior randomBehavior = (EnemyBehavior)Random.Range(0,_enemyBehaviorList.Count());
                baseDude.ChangeBehaviour(randomBehavior);
                var behavior = enemy.GetComponent(_enemyBehaviorList[(int)randomBehavior].GetType()) as Behaviour;
                baseDude.enabled = true;
                behavior.enabled = true;
                break;
        }
    }

    private void Awake()
    {
        _enemyBehaviorList = _enemyBehaviorContainerObject.GetComponents<IEnemyBehavior>().ToList();
    }

    private void Start()
    {
        _verticalBorder = Border.GetBorder("vertical") + _verticalOffset;
        _horizontalBorder = Border.GetBorder("horizontal");
        _spawnPointsList = new List<float>();
        _spawnPointsList = GetSpawnPoints(_horizontalBorder, _enemyOnScreen);
        _enemies = new List<GameObject>();
        for (int index = 0; index < _spawnPointsList.Count(); index++)
        {
            SpawnEnemy(_spawnPointsList[index]);
        }
    }


}
