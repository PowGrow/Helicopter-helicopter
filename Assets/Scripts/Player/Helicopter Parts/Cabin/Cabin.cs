using UnityEngine;

[CreateAssetMenu(fileName = "Cabin", menuName = "ScriptableObjects/Helicopter Cabin", order = 1)]
public class Cabin : ScriptableObject
{
    public int Id;
    public float CabinHealth;
    public float CabinArmor;
    public Sprite Sprite;
    public int Price;
    public string Description;
}
