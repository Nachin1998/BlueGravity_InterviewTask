using System.IO;
using System.Collections.Generic;

using UnityEngine;

using BlueGravity.Common.Currencies;

using Newtonsoft.Json;
using System;

public class ShopController : MonoBehaviour
{
    [Header("Main Configuration")]
    [SerializeField] private ShopView view = null;
    [SerializeField] private ShopConfirmationView confirmationView = null;
    [SerializeField] private ShopKeeperView shopKeeperView = null;
    
    [SerializeField] private CurrenciesController currenciesController = null;

    [Header("Items Configuration")]
    [SerializeField] private List<ShopItemSO> items = null;

    private List<PurchasedItemModel> purchasedItems = null;

    private const string purchaseHistoryFileName = "purchasehistory";

    public void Init()
    {
        view.Init(confirmationView.Configure, 
            onPanelClosed: () =>
            {
                shopKeeperView.ToggleIsInteractable(true);
                confirmationView.Toggle(false);
            });

        shopKeeperView.Init(
            onInteracted: () =>
            {
                if (purchasedItems == null)
                {
                    purchasedItems = LoadPurchaseHistory();
                }
                Configure();
                ToggleView(true);
            }, 
            null,
            onCustomerLeave: () => 
            {
                view.ClosePanel();
                confirmationView.Toggle(false);
            });

        confirmationView.Init(
            onConfirm: (itemView) =>
            {
                ShopItemSO item = GetShopItem(itemView.Id);
                PurchaseItem(item, 
                    onSuccess: () =>
                    {
                        itemView.Configure(item);
                    }, 
                    null);
            });
    }

    private void OnDisable()
    {
        SavePurchaseHistory();
        ResetShopItems();
    }

    private void SavePurchaseHistory()
    {
        FileHandler.SaveFile(purchaseHistoryFileName, purchasedItems);
    }

    private void ResetShopItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].SetIsPurchased(false);
        }
    }

    private List<PurchasedItemModel> LoadPurchaseHistory()
    {
        if (FileHandler.TryLoadFile(purchaseHistoryFileName, out List<PurchasedItemModel> data))
        {
            data ??= new List<PurchasedItemModel>();
            return data;
        }

        return new List<PurchasedItemModel>();
    }

    private void Configure()
    {
        for (int i = 0; i < purchasedItems.Count; i++)
        {
            ShopItemSO item = GetShopItem(purchasedItems[i].ItemId);

            if (item != null)
            {
                item.SetIsPurchased(purchasedItems[i].IsPurchased);
            }
        }

        view.Configure(items);
    }

    private ShopItemSO GetShopItem(string id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Id == id)
            {
                return items[i];
            }
        }

        Debug.LogError("Shop item of id " + id + " was not found");
        return null;
    }

    private void PurchaseItem(ShopItemSO item, Action onSuccess, Action onFailure)
    {
        int currentCurrencyValue = currenciesController.GetCurrencyValue(item.CurrencyType);
        bool canPurchase = currentCurrencyValue >= item.Price && !item.IsPurchased;

        if (canPurchase)
        {
            currenciesController.SubstractCurrency(item.CurrencyType, item.Price);
            purchasedItems.Add(new PurchasedItemModel(item.Id, true));
            item.SetIsPurchased(true);
            confirmationView.Toggle(false);
            Debug.Log("Item Purchased successfully!");
            onSuccess?.Invoke();
        }
        else
        {
            Debug.LogWarning("Not enough " + item.CurrencyType.Id);
            onFailure?.Invoke();
        }

    }

    public void ToggleView(bool status)
    {
        view.Toggle(status);
    }
}
