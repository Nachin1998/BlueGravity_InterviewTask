using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Pool;

namespace BlueGravity.Common.Currencies
{
    public class CurrenciesView : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private Transform holder = null;
        [SerializeField] private Transform itemsHolder = null;
        [SerializeField] private CurrencyItemView currencyItemPrefab = null;

        private ObjectPool<CurrencyItemView> currenciesPool = null;
        private List<CurrencyItemView> activeItems = null;

        public void Init(List<CurrencySO> currencies, List<CurrencyModel> models)
        {
            currenciesPool = new ObjectPool<CurrencyItemView>(GenerateItem, GetItem, ReleaseItem);
            activeItems = new List<CurrencyItemView>();

            for (int i = 0; i < currencies.Count; i++)
            {
                CurrencyItemView item = currenciesPool.Get();
                item.Configure(currencies[i], models[i]);
                activeItems.Add(item);
            }
        }

        public void UpdateCurrencyView(string id, int newValue)
        {
            for (int i = 0; i < activeItems.Count; i++)
            {
                if (activeItems[i].Id == id)
                {
                    activeItems[i].SetValue(newValue);
                }
            }
        }

        private CurrencyItemView GenerateItem()
        {
            return Instantiate(currencyItemPrefab, itemsHolder);
        }

        private void GetItem(CurrencyItemView item)
        {
            item.Toggle(true);
        }

        private void ReleaseItem(CurrencyItemView item)
        {
            item.Toggle(false);
        }
    }
}