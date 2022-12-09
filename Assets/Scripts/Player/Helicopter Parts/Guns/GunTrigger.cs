using UnityEngine;

public class GunTrigger : MonoBehaviour
{
    private float _timer;
    private GunInfo _gunInfo;


    public GameObject Click(Vector2 gunPosition, Quaternion gunRotation)
    {
        if(_timer >= _gunInfo.ShootingInterval)
        {
            var _bullet = Instantiate(_gunInfo.ProjectilePrefab);
            _bullet.transform.SetPositionAndRotation(gunPosition, gunRotation);
            _timer = 0;
            return _bullet;
        }
        return null;
    }

    void Update()
    {
        _timer += Time.deltaTime;
    }

    private void Awake()
    {
        _gunInfo = GetComponent<GunInfo>();
    }

    private void Start()
    {
        _timer = 0;
    }
}
