using BlueGravity.Common.Currencies;
using UnityEngine;

public class GameCurrenciesController : CurrenciesController
{
    [SerializeField] private GameCurrenciesView view = null;

    public override void Init()
    {
        base.Init();
        view.Init(currencies, currenciesValues);
    }

    public override int AddCurrency(CurrencySO currency, int valueToAdd)
    {
        int newValue = base.AddCurrency(currency, valueToAdd);
        view.UpdateCurrencyView(currency.Id, newValue);
        return newValue;
    }

    public override int SubstractCurrency(CurrencySO currency, int valueToSubstract)
    {
        int newValue = base.SubstractCurrency(currency, valueToSubstract);
        view.UpdateCurrencyView(currency.Id, newValue);
        return newValue;
    }
}
