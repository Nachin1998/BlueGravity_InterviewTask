using System;
using System.Collections.Generic;

using UnityEngine;

using BlueGravity.Common.Currencies;

public class ShopController : MonoBehaviour
{
    [Header("Main Configuration")]
    [SerializeField] private ShopView view = null;
    [SerializeField] private ShopConfirmationView confirmationView = null;
    [SerializeField] private ShopKeeperView shopKeeperView = null;

    [SerializeField] private GameCurrenciesController currenciesController = null;

    [Header("Items Configuration")]
    [SerializeField] private List<ShopItemSO> items = null;
    [SerializeField] private AudioChannel audioChannel = null;
    [SerializeField] private AudioSO purchaseSFX = null;

    [Header("Audio Configuration")]

    private List<PurchasedItemModel> purchasedItems = null;

    private Action<ShopItemSO> OnItemPurchased = null;
    private Action<ShopItemSO> OnItemSold = null;

    private const string purchaseHistoryFileName = "purchasehistory";

    private enum SHOP_TRANSACTION_TYPE
    {
        PURCHASING,
        SELLING
    }

    public void Init(Action<ShopItemSO> onItemPurchased, Action<ShopItemSO> onItemSold)
    {
        OnItemPurchased = onItemPurchased;
        OnItemSold = onItemSold;

        ConfigureItems();

        view.Init(confirmationView.Configure,
            onPanelClosed: () =>
            {
                shopKeeperView.ToggleIsInteractable(true);
                confirmationView.Toggle(false);
            });

        shopKeeperView.Init(
            onInteracted: () =>
            {
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
                ProcessTransaction(item,
                    onSuccess: () =>
                    {
                        itemView.Configure(item);
                        view.Toggle(true);
                    },
                    null);
            });
    }

    public void DeInit()
    {
        SavePurchaseHistory();
        ResetShopItems();
    }

    private void ConfigureItems()
    {
        purchasedItems = LoadPurchaseHistory();

        for (int i = 0; i < purchasedItems.Count; i++)
        {
            ShopItemSO item = GetShopItem(purchasedItems[i].ItemId);

            if (item != null)
            {
                item.ToggleIsPurchased(purchasedItems[i].IsPurchased);
            }
        }
    }

    private void SavePurchaseHistory()
    {
        FileHandler.SaveFile(purchaseHistoryFileName, purchasedItems);
    }

    private void ResetShopItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].ToggleIsPurchased(false);
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

    private void ProcessTransaction(ShopItemSO item, Action onSuccess, Action onFailure)
    {
        SHOP_TRANSACTION_TYPE type = item.IsPurchased ? SHOP_TRANSACTION_TYPE.SELLING : SHOP_TRANSACTION_TYPE.PURCHASING;

        onSuccess += () => audioChannel.OnTriggerAudio?.Invoke(purchaseSFX);

        switch (type)
        {
            case SHOP_TRANSACTION_TYPE.PURCHASING:
                PurchaseItem(item, onSuccess, onFailure);
                break;
            case SHOP_TRANSACTION_TYPE.SELLING:
                SellItem(item, onSuccess, onFailure);
                break;
        }
    }

    private void PurchaseItem(ShopItemSO item, Action onSuccess, Action onFailure)
    {
        int currentCurrencyValue = currenciesController.GetCurrencyValue(item.CurrencyType);
        bool canPurchase = currentCurrencyValue >= item.Price && !item.IsPurchased;

        if (canPurchase)
        {
            currenciesController.SubstractCurrency(item.CurrencyType, item.Price);
            purchasedItems.Add(new PurchasedItemModel(item.Id, true));
            item.ToggleIsPurchased(true);
            confirmationView.Toggle(false);
            Debug.Log("Item Purchased successfully!");
            OnItemPurchased?.Invoke(item);
            onSuccess?.Invoke();
        }
        else
        {
            Debug.LogWarning("Not enough " + item.CurrencyType.Id);
            onFailure?.Invoke();
        }
    }

    private void SellItem(ShopItemSO item, Action onSuccess, Action onFailure)
    {
        bool canSell = item.IsPurchased;

        if (canSell)
        {
            currenciesController.AddCurrency(item.CurrencyType, item.SellingPrice);
            item.ToggleIsPurchased(false);
            GetPurchasedItem(item.Id).ToggleIsPurchased(false);
            purchasedItems.Add(new PurchasedItemModel(item.Id, true));

            confirmationView.Toggle(false);
            Debug.Log("Item Sold successfully!");
            OnItemSold?.Invoke(item);
            onSuccess?.Invoke();
        }
        else
        {
            Debug.LogWarning("There was an error in the selling process");
            onFailure?.Invoke();
        }
    }

    private PurchasedItemModel GetPurchasedItem(string id)
    {
        for (int i = 0; i < purchasedItems.Count; i++)
        {
            if (purchasedItems[i].ItemId == id)
            {
                return purchasedItems[i];
            }
        }

        Debug.LogWarning("Purchase model of id " + id + " was not found");
        return null;
    }

    public void ToggleView(bool status)
    {
        view.Toggle(status);
    }
}
