using UnityEngine;

public class EnemyMainMenu : MonoBehaviour
{
    private Vector2 _spawnPosition;

    void Start()
    {
        var orthographicSize = Camera.main.orthographicSize;
        var y = orthographicSize + 2f;
        var screenWidth = orthographicSize * ((float)Screen.width / (float)Screen.height);
        var x = Random.Range(-1 * screenWidth, screenWidth);
        _spawnPosition = new Vector2(x, y);
        transform.position = _spawnPosition;
    }

    void Update()
    {
        transform.Translate(new Vector3 (0,Time.deltaTime,0));
    }
}
