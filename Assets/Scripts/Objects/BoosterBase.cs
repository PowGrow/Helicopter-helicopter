using UnityEngine;

public class BoosterBase : MonoBehaviour
{
    [SerializeField] private float _dropSpeed;
    [SerializeField] protected float value;
    protected Buffs _playerBuffs;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _playerBuffs = Managers.GameObjects.GetObject("Player").GetComponent<Buffs>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = Vector2.down * _dropSpeed;
        if (this.transform.position.y < -1 * (Border.GetBorder("vertical") + 1f))
            Destroy(this.gameObject);
    }
}
