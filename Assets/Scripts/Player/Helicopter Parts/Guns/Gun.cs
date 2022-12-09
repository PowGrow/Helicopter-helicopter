using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "ScriptableObjects/Helicopter Weapon", order = 1)]
public class Gun : ScriptableObject
{
    public int Id;
    public float ShootingInterval;
    public float DamageMultiplier;
    public GameObject ProjectilePrefab;
    public Sprite Sprite;
    public int Price;
    public string Description;
}
