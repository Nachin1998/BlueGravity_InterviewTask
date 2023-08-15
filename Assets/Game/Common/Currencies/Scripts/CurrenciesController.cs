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

        private const string currenciesPath = "/currencies";

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
    }
}