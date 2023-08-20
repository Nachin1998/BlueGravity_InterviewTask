using UnityEngine;

using BlueGravity.Common.Currencies;

namespace BlueGravity.Game.Hub.Modules.Currencies
{
    public class GameCurrenciesController : CurrenciesController
    {
        [Header("Main Configuration")]
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
}