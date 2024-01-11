using System.Collections.Generic;

using UnityEngine;

namespace BlueGravity.Common.Currencies
{
    public class CurrenciesController : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] protected List<CurrencySO> currencies = null;
        [SerializeField] protected CurrenciesView view = null;

        [Header("Debug values")]
        [SerializeField] private int currenciesInitialValue = 0;

        protected List<CurrencyModel> currenciesValues = null;

        public void Init()
        {
            currenciesValues = new List<CurrencyModel>();
            ConfigureCurrencies();
            view.Init(currencies, currenciesValues);
        }

        private void ConfigureCurrencies()
        {
            for (int i = 0; i < currencies.Count; i++)
            {
                currenciesValues.Add(new CurrencyModel(currencies[i].Id, currenciesInitialValue));
            }
        }

        public int GetCurrencyValue(CurrencySO currency)
        {
            return GetCurrencyValue(currency.Id);
        }

        public int AddCurrency(CurrencySO currency, int valueToAdd)
        {
            CurrencyModel model = GetCurrencyModel(currency.Id);
            model.Value += valueToAdd;
            return model.Value;
        }

        public int SubstractCurrency(CurrencySO currency, int valueToSubstract)
        {
            CurrencyModel model = GetCurrencyModel(currency.Id);
            model.Value -= valueToSubstract;
            return model.Value;
        }

        public int GetCurrencyValue(string currencyId)
        {
            CurrencyModel model = GetCurrencyModel(currencyId);
            return model.Value;
        }

        private CurrencyModel GetCurrencyModel(string currencyId)
        {
            for (int i = 0; i < currenciesValues.Count; i++)
            {
                if (currenciesValues[i].Id == currencyId)
                {
                    return currenciesValues[i];
                }
            }

            Debug.LogError("Currency of id " + currencyId + " was not found.");
            return null;
        }
    }
}