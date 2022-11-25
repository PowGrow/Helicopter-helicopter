using System.Collections.Generic;
using UnityEngine;

//Создержит список со всеми спрайтами частей вертолёта
public class UISpriteList : MonoBehaviour
{
    [SerializeField] private List<Sprite> _guns;
    [SerializeField] private List<Sprite> _cabins;
    [SerializeField] private List<Sprite> _wings;

    public List<Sprite> GetGunSpriteList()
    {
        return _guns;
    }
    public List<Sprite> GetCabinSpriteList()
    {
        return _cabins;
    }
    public List<Sprite> GetWingSpriteList()
    {
        return _wings;
    }
}
