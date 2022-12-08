using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private int  startCountOfEnemy;
    [SerializeField] private int countEnemy;
    [SerializeField] private float moveDownYposition;
    [SerializeField] private int waweOfEnemiesCount;
    [SerializeField] private int _curentLineEnemiesCount;
    [SerializeField] public int lineOfEnemies = 0;
    public Vector3 pointOfEdge;
    public int curentLineEnemiesCount
    {
        get
        {
            return _curentLineEnemiesCount;
        }
        set
        {
            _curentLineEnemiesCount = value;
            if(_curentLineEnemiesCount == 0)
            {
                if (countEnemy  < waweOfEnemiesCount)
                {
                    spawnObjectsByLine(countEnemy);
                    countEnemy = 0;
                }
                else
                {
                    spawnObjectsByLine(waweOfEnemiesCount);
                    countEnemy -= waweOfEnemiesCount;
                }
            }
        }
    }
    [SerializeField] private List<GameObject> prefabList;
    [Header("Лист волн врагов")]
    [SerializeField] public List<GameObject> enemyList;
    void Start()
    {
        startCountOfEnemy = countEnemy;
        Vector3 point = new Vector3(0, Screen.height, 0);
        this.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(point).x, this.transform.position.y);
        curentLineEnemiesCount = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void spawnObjectsByLine(int count)
    {
        List<GameObject> enemiesWawe = new List<GameObject>();
        for (int i = 0; i < count; i++)
        {
            int selectEnemy = Random.Range(0, prefabList.Count);
            GameObject obj = Instantiate(prefabList[selectEnemy]);
            enemiesWawe.Add(obj);
            obj.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / (count*1.5f)*(i+0.5f), Screen.height, Camera.main.nearClipPlane)).x, transform.position.y , transform.position.z);
            pointOfEdge = obj.transform.position;
        }
        curentLineEnemiesCount = count;
        enemyList=enemiesWawe;
        StartCoroutine(moveToDefaultPosition());
    }

    IEnumerator moveToDefaultPosition()
    {
        for (float i = 0; i < 0.25; i += 0.01f)
        {

                foreach (GameObject obj in enemyList)
                {
                    Vector3 target = new Vector3(obj.transform.position.x, obj.transform.position.y - moveDownYposition, this.transform.position.z);
                    obj.transform.position = Vector3.MoveTowards(obj.transform.position, target, moveDownYposition * 0.04f);
                }
            
            yield return new WaitForSeconds(0.01f);
        }
     foreach(GameObject obj in enemyList)
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
                AIFollowing._speed *= (1 + (float)(startCountOfEnemy - countEnemy) / 100);
                break;
            case 1:
                EnemyAxisMoving AIMoving = obj.gameObject.AddComponent<EnemyAxisMoving>();
                AIMoving.endlessPosition = new Vector3(Random.Range(this.transform.position.x+1, pointOfEdge.x), Random.Range(0f, 3f), 0);
                obj.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                obj.gameObject.layer = 15;
                AIMoving._speed *= (1 + (float)(startCountOfEnemy - countEnemy) / 100);
                break;
        }
       

    }
}
