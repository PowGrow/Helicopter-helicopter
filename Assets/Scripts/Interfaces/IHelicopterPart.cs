
using System.Collections.Generic;
using UnityEngine;

public interface IHelicopterPart
{
    public int Id { get; set; }
    public Sprite Sprite { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public string Type { get; }

    public List<GameObject> ObjectList { get; }
    public GameObject partGameObject { get; }
}
