using Newtonsoft.Json.Linq;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GearCurrency : MonoBehaviour
{
    private Currency _currencyObject;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;

    public Currency CurrencyObject
    {
        get { return _currencyObject; }
        set
        {
            _currencyObject = value;
            _spriteRenderer.sprite = _currencyObject.Sprite;
        }
    }
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _rigidBody.velocity = Vector2.down;  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Managers.Configuration.Currency += _currencyObject.Value;
        Debug.Log($" + {_currencyObject.Value} gears");
        Destroy(this.gameObject);
    }
}
