using System.Collections.Generic;
using System.IO;

using UnityEngine;

using Newtonsoft.Json;

namespace BlueGravity.Common.Currencies
{
    public class CurrenciesController : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private List<CurrencySO> currencies = null;

        [Header("Debug values")]
        [SerializeField] private bool debugMode = false;
        [SerializeField] private int currenciesInitialValue = 0;

        private List<CurrencyModel> currenciesValues = null;

        private const string currenciesFileName = "currencies";

        public void Init()
        {
            currenciesValues = new List<CurrencyModel>();
            LoadCurrencies();
        }

        public void DeInit()
        {
            SaveCurrencies();
        }

        private void SaveCurrencies()
        {
            FileHandler.SaveFile(currenciesFileName, currenciesValues);
        }

        private void LoadCurrencies()
        {
            if (debugMode)
            {
                for (int i = 0; i < currencies.Count; i++)
                {
                    currenciesValues.Add(new CurrencyModel(currencies[i].Id, debugMode ? currenciesInitialValue : 0));
                }
            }
            else
            {
                CheckLocalFile();
            }
        }

        private void CheckLocalFile()
        {
            if (FileHandler.TryLoadFile(currenciesFileName, out List<CurrencyModel> data))
            {
                currenciesValues = data;
            }
            else
            {
                for (int i = 0; i < currencies.Count; i++)
                {
                    currenciesValues.Add(new CurrencyModel(currencies[i].Id, 0));
                }
            }
        }

        public int GetCurrencyValue(CurrencySO currency)
        {
            return GetCurrencyValue(currency.Id);
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