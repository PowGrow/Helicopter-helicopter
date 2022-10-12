using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "ScriptableObjects/Helicopter Weapon", order = 1)]
public class Gun : ScriptableObject
{
    public float shootingInterval;
    public GunType gunType;
    public GameObject bulletPrefab;
}
