using UnityEngine;

public class HelicopterAnimationController : MonoBehaviour
{
    private Animator _ventAnimator;
    private Rigidbody2D _helicopterRigidbody2d;
    private void Awake()
    {
        _helicopterRigidbody2d = gameObject.GetComponentInParent<Rigidbody2D>();
        _ventAnimator = GetComponent<Animator>();
        
    }

    private void FixedUpdate()
    {
        _ventAnimator.SetFloat("VelocityX", _helicopterRigidbody2d.velocity.x);
        _ventAnimator.SetFloat("VelocityY", _helicopterRigidbody2d.velocity.y);
    }
}
