using System.IO;
using System.Collections.Generic;

using UnityEngine;

using BlueGravity.Common.Currencies;

using Newtonsoft.Json;

public class ShopController : MonoBehaviour
{
    [Header("Main Configuration")]
    [SerializeField] private ShopKeeperView shopKeeperView = null;
    [SerializeField] private ShopConfirmationView confirmationView = null;
    [SerializeField] private ShopView view = null;
    [SerializeField] private CurrenciesController currenciesController = null;

    [Header("Items Configuration")]
    [SerializeField] private List<ShopItemSO> items = null;

    private List<PurchasedItemModel> purchasedItems = null;

    private const string purchaseHistoryPath = "/purchasehistory.dat";

    public void Init()
    {
        view.Init(confirmationView.Configure, null);

        shopKeeperView.Init(
            onInteracted: () =>
            {
                Configure();
                ToggleView(true);
            });

        confirmationView.Init(
            onConfirm: (itemId) =>
            {
                ShopItemSO item = GetShopItem(itemId);
                PurchaseItem(item);
            });

        purchasedItems = LoadPurchaseHistory();
    }

    private void OnDisable()
    {
        SavePurchaseHistory();
    }

    private void SavePurchaseHistory()
    {
        string data = JsonConvert.SerializeObject(items);
        File.WriteAllText(Application.persistentDataPath + purchaseHistoryPath, data);
    }

    private List<PurchasedItemModel> LoadPurchaseHistory()
    {
        if (!File.Exists(Application.persistentDataPath + purchaseHistoryPath))
        {
            return new List<PurchasedItemModel>();
        }

        string data = File.ReadAllText(Application.persistentDataPath + purchaseHistoryPath);
        List<PurchasedItemModel> models = JsonConvert.DeserializeObject<List<PurchasedItemModel>>(data);
        return models;
    }

    private void Configure()
    {
        for (int i = 0; i < purchasedItems.Count; i++)
        {
            ShopItemSO item = GetShopItem(purchasedItems[i].ItemId);
            item.SetIsPurchased(purchasedItems[i].IsPurchased);
        }

        view.Configure(items);
    }

    private ShopItemSO GetShopItem(string id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Item.Id == id)
            {
                return items[i];
            }
        }

        Debug.LogError("Shop item of id " + id + " was not found");
        return null;
    }

    private void PurchaseItem(ShopItemSO item)
    {
        int currentCurrencyValue = currenciesController.GetCurrencyValue(item.CurrencyType);
        bool canPurchase = currentCurrencyValue >= item.Price && !item.IsPurchased;

        if (canPurchase)
        {
            purchasedItems.Add(new PurchasedItemModel(item.Item.Id, true));
        }
        else
        {

        }
    }

    public void ToggleView(bool status)
    {
        view.Toggle(status);
    }
}
