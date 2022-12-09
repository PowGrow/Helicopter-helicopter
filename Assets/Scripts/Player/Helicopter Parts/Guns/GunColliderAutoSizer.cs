using UnityEngine;

public class GunColliderAutoSizer : MonoBehaviour
{
    private BoxCollider2D _gunBoxCollider;
    private SpriteRenderer _gunSpriteRenderer;

    
    private void AutoSizeCollider(BoxCollider2D boxCollider, SpriteRenderer sprite)
    {
        boxCollider.offset = Vector2.zero;
        boxCollider.size = new Vector2((sprite.sprite.textureRect.size.x / 100) * 2, (sprite.sprite.textureRect.size.y / 100) * 2);
    }

    
    private void Start()
    {
        AutoSizeCollider(_gunBoxCollider, _gunSpriteRenderer);
    }

    
    private void Awake()
    {
        _gunBoxCollider = GetComponent<BoxCollider2D>();
        _gunSpriteRenderer = GetComponent<SpriteRenderer>();
    }
}
