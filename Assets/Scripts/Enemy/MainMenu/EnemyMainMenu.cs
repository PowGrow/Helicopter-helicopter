using UnityEngine;

public class EnemyMainMenu : MonoBehaviour
{
    private Vector2 _spawnPosition;
    private Vector3 _destinationPosition;
    void Start()
    {
        var y = Camera.main.orthographicSize + 2f;
        var screenWidth = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
        var x = Random.Range(-1 * screenWidth, screenWidth);
        _spawnPosition = new Vector2(x, y);
        transform.position = _spawnPosition;
        _destinationPosition = new Vector3(transform.position.x, -1 * _spawnPosition.y, 0);
    }

    void Update()
    {
        this.transform.Translate(Vector2.down * Time.deltaTime);
    }
}
