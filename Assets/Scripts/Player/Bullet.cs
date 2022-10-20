using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile, IProjectile
{
    private void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
