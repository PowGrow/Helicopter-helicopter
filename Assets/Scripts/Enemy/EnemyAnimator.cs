using System;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    private Animator _animator;

    public Action<GameObject> OnEnemyDestroyAnimationPlayed;
    public Action<bool> OnEnemyArrival;
    public Func<SpriteRenderer> IsEnemyDestroyed;

    private void EnemyDie()
    {
        OnEnemyArrival?.Invoke(false);
        _animator.Play("explosion");
    }
    public void DestroyEnemy()
    {
        OnEnemyDestroyAnimationPlayed?.Invoke(transform.parent.gameObject);
        Destroy(transform.parent.gameObject);
    }

    public void EnemyArrived()
    {
        OnEnemyArrival?.Invoke(true);
    }

    public void HideEnemySprite()
    {
        var spriteRenderer = IsEnemyDestroyed?.Invoke();
        spriteRenderer.sprite = null;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _enemyHealth.OnEnemyDying += EnemyDie;   
    }
    private void OnDisable()
    {
        _enemyHealth.OnEnemyDying += EnemyDie;
    }
}
