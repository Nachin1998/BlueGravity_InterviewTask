using System;
using System.Collections.Generic;

using UnityEngine;

namespace BlueGravity.Common.Currencies
{
    public class CurrenciesController : MonoBehaviour
    {
        #region EXPOSED_FIELDS
        [Header("Main Configuration")]
        [SerializeField] private List<CurrencySO> currencies = null;
        [SerializeField] private CurrenciesView view = null;

        [Header("Debug values")]
        [SerializeField] private int currenciesInitialValue = 0;
        #endregion

        #region PRIVATE_FIELDS
        private List<CurrencyModel> currenciesValues = null;
        #endregion

        #region ACTIONS
        public event Action<CurrencyModel> OnCurrencyUpdated = null;
        #endregion

        #region PUBLIC_METHODS
        public void Init()
        {
            currenciesValues = new List<CurrencyModel>();
            OnCurrencyUpdated += view.UpdateCurrencyView;

            ConfigureCurrencies();
            
            view.Init(currencies, currenciesValues);
        }

        public int GetCurrencyValue(CurrencySO currency)
        {
            return GetCurrencyValue(currency.Id);
        }

        public int AddCurrency(CurrencySO currency, int valueToAdd)
        {
            CurrencyModel model = GetCurrencyModel(currency.Id);
            model.Value += valueToAdd;
            OnCurrencyUpdated?.Invoke(model);
            return model.Value;
        }

        public int SubstractCurrency(CurrencySO currency, int valueToSubstract)
        {
            CurrencyModel model = GetCurrencyModel(currency.Id);
            model.Value -= valueToSubstract;
            OnCurrencyUpdated?.Invoke(model);
            return model.Value;
        }

        public int GetCurrencyValue(string currencyId)
        {
            CurrencyModel model = GetCurrencyModel(currencyId);
            return model.Value;
        }
        #endregion

        #region PRIVATE_METHODS
        private void ConfigureCurrencies()
        {
            for (int i = 0; i < currencies.Count; i++)
            {
                currenciesValues.Add(new CurrencyModel(currencies[i].Id, currenciesInitialValue));
            }
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
        #endregion
    }
}