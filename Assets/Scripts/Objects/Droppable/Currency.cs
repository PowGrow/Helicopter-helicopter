using UnityEngine;

[CreateAssetMenu(fileName = "CurrencyObject", menuName = "ScriptableObjects/Currency", order = 1)]
public class Currency : ScriptableObject
{
    public int Value;
    public Sprite Sprite;
}
