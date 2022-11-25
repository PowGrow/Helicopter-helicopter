using UnityEngine;

public class Shooting : MonoBehaviour
{
    private IShooter _shooter;
    private PlayerControls _playerControls;
    private bool _isShooting = false;

    private void Shoot()
    {
        _isShooting = true;
    }

    private void StopShooting()
    {
        _isShooting = false;
    }

    private void FixedUpdate()
    {
        if (_isShooting)
            _shooter.Fire();
    }

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _shooter = GetComponent<IShooter>();
    }

    private void OnEnable()
    {
        _playerControls.Enable();

        _playerControls.Player.Mouse.performed += callbackContext => Shoot();
        _playerControls.Player.Mouse.canceled += callbackContext => StopShooting();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }
}
