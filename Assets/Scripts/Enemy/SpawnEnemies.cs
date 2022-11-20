using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private int countEnemy;
    [SerializeField] private float cameraSize;
    [SerializeField] private float moveDownYposition;
    [SerializeField] private int waweOfEnemiesCount;
    [SerializeField] public int lineOfEnemies = 0;
    [SerializeField] public int curentLineEnemiesCount;
    [SerializeField] private List<GameObject> prefabList;
    [Header("Лист волн врагов")]
    [SerializeField] public List<List<GameObject>> enemyList = new List<List<GameObject>>();
    void Start()
    {

        for (int i = 0; i <= countEnemy; i += waweOfEnemiesCount)
        {
            if (countEnemy - i < waweOfEnemiesCount)
            {
                spawnObjectsByLine(countEnemy - i, i / waweOfEnemiesCount);
            }
            else
            {
                spawnObjectsByLine(waweOfEnemiesCount, i / waweOfEnemiesCount);
            }

        }
        StartCoroutine(moveToDefaultPosition());
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyList[lineOfEnemies].Count==0)
        {

            StartCoroutine(moveToDefaultPosition());
            lineOfEnemies += 1;
        }
    }
    void spawnObjectsByLine(int count, int line)
    {
        List<GameObject> enemiesWawe = new List<GameObject>();
        for (int i = 0; i < count; i++)
        {
            int selectEnemy = Random.Range(0, prefabList.Count);
            GameObject obj = Instantiate(prefabList[selectEnemy]);
            enemiesWawe.Add(obj);
            obj.transform.position = new Vector3(transform.position.x + i * cameraSize / count + cameraSize / count - 1, transform.position.y + line+(moveDownYposition-1)*line, transform.position.z);
        }
        enemyList.Add(enemiesWawe);
    }

    IEnumerator moveToDefaultPosition()
    {
        for (float i = 0; i < 0.25; i += 0.01f)
        {
            foreach (List<GameObject> enemies in enemyList)
            {
                foreach (GameObject obj in enemies)
                {
                    Vector3 target = new Vector3(obj.transform.position.x, obj.transform.position.y - moveDownYposition, this.transform.position.z);
                    obj.transform.position = Vector3.MoveTowards(obj.transform.position, target, moveDownYposition * 0.04f);
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
     foreach(GameObject obj in enemyList[lineOfEnemies])
        {
            componentsUsing(obj, true);
        }
    }
    void componentsUsing(GameObject obj,bool componentEnable)
    {
        int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                EnemyAxisFollowing AIFollowing = obj.gameObject.AddComponent<EnemyAxisFollowing>();
                break;
            case 1:
                EnemyAxisMoving AIMoving = obj.gameObject.AddComponent<EnemyAxisMoving>();
                AIMoving._movementDirection = new Vector3(Random.Range(0f, 5f),0,0);
                obj.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                obj.gameObject.layer = 15;
                break;
        }
       

    }
}
