using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoosterLoot : MonoBehaviour, IDroppable
{
    [SerializeField] private List<GameObject> _boosterToDrop;
    [SerializeField] private float _dropChance;
    public float DropChance
    {
        get { return _dropChance;}
    }
    public void DropItem()
    {
        var droppedObject = Instantiate(_boosterToDrop[Random.Range(0,_boosterToDrop.Count())]);
        droppedObject.transform.position = this.transform.position;
        Debug.Log($"Dropped {droppedObject.name}");
    }
}
