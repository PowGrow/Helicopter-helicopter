using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile
{
    public float DamageModificator { get; set; }
    public float SpeedModificator { get; set; }
    public float LifetimeModificator { get; set; }
}
