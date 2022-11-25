using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wing", menuName = "ScriptableObjects/Helicopter Wing", order = 1)]
public class Wing : ScriptableObject
{
    public int Id;
    public List<Vector2> MountPoints;
    public Sprite Sprite;
    public int Price;
    public string Description;
}
