using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private PlayerControls _playerControls;
    private bool _isShooting = false;
    [SerializeField]
    private GameObject _bulletPrefab;
    private GameObject _bullet;

    private void Shoot()
    {
        _isShooting = true;
    }

    private void StopShooting()
    {
        _isShooting = false;
    }

    private void Update()
    {
        if(_isShooting)
        {
            _bullet = Instantiate(_bulletPrefab) as GameObject;
            _bullet.transform.position = transform.TransformPoint(Vector2.up);
            _bullet.transform.rotation = transform.rotation;
        }
            
    }

    private void Awake()
    {
        _playerControls = new PlayerControls();
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
