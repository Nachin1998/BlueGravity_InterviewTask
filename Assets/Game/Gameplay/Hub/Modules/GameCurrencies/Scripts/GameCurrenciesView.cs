using BlueGravity.Common.Currencies;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GameCurrenciesView : MonoBehaviour
{
    [SerializeField] private Transform holder = null;
    [SerializeField] private Transform itemsHolder = null;
    [SerializeField] private GameCurrencyItemView currencyItemPrefab = null;

    private ObjectPool<GameCurrencyItemView> currenciesPool = null;
    private List<GameCurrencyItemView> activeItems = null;

    public void Init(List<CurrencySO> currencies, List<CurrencyModel> models)
    {
        currenciesPool = new ObjectPool<GameCurrencyItemView>(GenerateItem, GetItem, ReleaseItem);
        activeItems = new List<GameCurrencyItemView>();

        for (int i = 0; i < currencies.Count; i++)
        {
            GameCurrencyItemView item = currenciesPool.Get();
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

    private GameCurrencyItemView GenerateItem()
    {
        return Instantiate(currencyItemPrefab, itemsHolder);
    }

    private void GetItem(GameCurrencyItemView item)
    {
        item.Toggle(true);
    }

    private void ReleaseItem(GameCurrencyItemView item)
    {
        item.Toggle(false);
    }
}
