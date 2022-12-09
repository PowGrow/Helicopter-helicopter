using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private List<IDroppable> _droppables = new List<IDroppable>();

    private void Awake()
    {
        _droppables = GetComponentsInChildren<IDroppable>().ToList();
    }

    private void OnDisable()
    {
        if (!this.gameObject.scene.isLoaded) return;
        foreach(IDroppable droppable  in _droppables)
        {
            var chance = Random.Range(1, 101);
            if (droppable.DropChance >= chance)
                droppable.DropItem();
        }
    }
}
