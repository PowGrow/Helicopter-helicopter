using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PartList", menuName = "ScriptableObjects/Helicopter parts", order = 2)]
public class PartsList : ScriptableObject
{
    public List<Sprite> Parts;
}
