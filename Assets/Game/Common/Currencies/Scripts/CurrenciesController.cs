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

        private const string currenciesPath = "/currencies.dat";

        public void Init()
        {
            currenciesValues = new List<CurrencyModel>();
            LoadCurrencies();
        }

        private void OnDisable()
        {
            if (!debugMode)
            {
                SaveCurrencies();
            }
        }

        private void SaveCurrencies()
        {
            string data = JsonConvert.SerializeObject(currenciesValues);
            File.WriteAllText(Application.persistentDataPath + currenciesPath, data);
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
            bool hasData = File.Exists(Application.persistentDataPath + currenciesPath);

            if (!hasData)
            {
                for (int i = 0; i < currencies.Count; i++)
                {
                    currenciesValues.Add(new CurrencyModel(currencies[i].Id, 0));
                }
                return;
            }

            string data = File.ReadAllText(Application.persistentDataPath + currenciesPath);
            currenciesValues = JsonConvert.DeserializeObject<List<CurrencyModel>>(data);
        }

        public int GetCurrencyValue(CurrencySO currency)
        {
            return GetCurrencyValue(currency.Id);
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