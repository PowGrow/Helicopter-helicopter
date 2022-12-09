using UnityEngine;

public class CurrencyLoot : MonoBehaviour, IDroppable
{
    [SerializeField] private GameObject _objectToDrop;
    [SerializeField] private float _dropChance;

    public float DropChance
    {
        get { return _dropChance; }
    }
    private int GetRandomCurrencyValue()
    {
        var random = Random.Range(0, 100);
        int currencyId;
        if (random >= 95)
            currencyId = 4;
        else if (random >= 80)
            currencyId = 3;
        else if (random >= 50)
            currencyId = 2;
        else currencyId = 1;
        return currencyId;
    }
    public void DropItem()
    {
        var droppedObject = Instantiate(_objectToDrop.gameObject);
        droppedObject.transform.position = this.transform.position;
        var currencyId = GetRandomCurrencyValue();
        var gearCurrency = droppedObject.GetComponent<GearCurrency>();
        gearCurrency.CurrencyObject = Resources.Load<Currency>($"ScriptableObjects/Currency/{currencyId}");
        Debug.Log($"Dropped {currencyId} gears");
    }
}
