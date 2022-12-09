using UnityEngine;

public class AutoAimDetector : MonoBehaviour
{
    AutoAimMissile _autoAimMissle;
    private void Awake()
    {
        _autoAimMissle = GetComponentInParent<AutoAimMissile>();
    }

    //Setting target aftter triggering collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_autoAimMissle.Target == null)
            _autoAimMissle.SetAimTarget(collision.transform.gameObject);
    }
}
