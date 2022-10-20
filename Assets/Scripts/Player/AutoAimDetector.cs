using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAimDetector : MonoBehaviour
{
    AutoAimMissile _autoAimMissle;
    private void Awake()
    {
        _autoAimMissle = GetComponentInParent<AutoAimMissile>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_autoAimMissle._target == null)
        {
            if (collision.transform.tag == "Enemy")
            {
                _autoAimMissle.SetAimTarget(collision.transform.gameObject);
            }
        }
    }
}
