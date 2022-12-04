using UnityEngine;

public class CurrencyDrop : MonoBehaviour
{
    [SerializeField] private GameObject _currencyGearPrefab;

    private int GenerateRandom()
    {
        var random = Random.Range(0, 100);
        var currencyId = 0;
        if (random >= 95)
            currencyId = 4;
        else if (random >= 80)
            currencyId = 3;
        else if (random >= 50)
            currencyId = 2;
        else currencyId = 1;
        return currencyId;
    }

    private void OnDisable()
    {
        var currencyObject = Instantiate(_currencyGearPrefab);
        currencyObject.transform.position = this.transform.position;
        var currencyId = GenerateRandom();
        var gearCurrency = currencyObject.GetComponent<GearCurrency>();
        gearCurrency.CurrencyObject = Resources.Load<Currency>($"ScriptableObjects/Currency/{currencyId.ToString()}");
        Debug.Log($"Dropped {currencyId} gears");
    }
}
