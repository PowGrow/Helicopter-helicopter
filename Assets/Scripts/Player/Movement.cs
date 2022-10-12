using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private PlayerControls _playerControls;
    private Rigidbody2D _body;

    private float _deltaX, _deltaY;

    private void Move()
    {
        Vector2 movement = new Vector2(_deltaX, _deltaY);
        _body.velocity = Vector2.ClampMagnitude(movement * _speed, 5f);
    }

    private void Update()
    {
        Move();
    }

    private void Awake()
    {
        _deltaX = 0;
        _deltaY = 0;
        _playerControls = new PlayerControls();
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        _body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
        _playerControls.Player.WASD.performed += callbackContext => SetMotion(callbackContext.ReadValue<Vector2>().x, callbackContext.ReadValue<Vector2>().y);
        _playerControls.Player.WASD.canceled += callbackContext => StopMotion();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void SetMotion(float x, float y)
    {
        _deltaX = x * Time.deltaTime;
        _deltaY = y * Time.deltaTime;
    }

    private void StopMotion()
    {
        _deltaX = 0;
        _deltaY = 0;
    }
}
