using UnityEngine;

public class GunColliderAutoSizer : MonoBehaviour
{
    private BoxCollider2D _gunBoxCollider; //Коллайдер пушки
    private SpriteRenderer _gunSpriteRenderer; //Компонент SpriteRenderer пушки

    //Метод устанавливающий размер коллайдера в зависимости от размера установленного в нём спрайта пушки
    private void AutoSizeCollider(BoxCollider2D boxCollider, SpriteRenderer sprite)
    {
        boxCollider.offset = Vector2.zero;
        boxCollider.size = new Vector2((sprite.sprite.textureRect.size.x / 100) * 2, (sprite.sprite.textureRect.size.y / 100) * 2);
    }

    //При старте вызывает метод изменяющий размер коллайдера
    private void Start()
    {
        AutoSizeCollider(_gunBoxCollider, _gunSpriteRenderer);
    }

    //Получаем нужные для работы компоненты
    private void Awake()
    {
        _gunBoxCollider = GetComponent<BoxCollider2D>();
        _gunSpriteRenderer = GetComponent<SpriteRenderer>();
    }
}
