using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Projectile
{
    private void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
