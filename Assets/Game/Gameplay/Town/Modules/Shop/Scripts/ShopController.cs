using System;

using UnityEngine;

using BlueGravity.Common.NPC;
using BlueGravity.Common.Currencies;

namespace BlueGravity.Game.Town.Modules.Shop
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private ShopView view = null;
        [SerializeField] private ConfirmPurchaseView confirmPurchaseView = null;
        [SerializeField] private CurrenciesController currenciesController = null;
        [SerializeField] private ShopItemSO[] items = null;
        [SerializeField] private NPCCharacterView shopKeeper = null;

        public event Action<bool> OnShopToggled = null;

        public void Init()
        {
            shopKeeper.OnInteracted += TriggerShop;
            view.OnShopToggled += OnShopToggled;
            view.OnItemPressed += ProcessItem;
            view.Init(items);

            confirmPurchaseView.Init();
        }

        private void ProcessItem(ShopItemView view)
        {
            ShopItemSO item = GetShopItem(view.Id);

            if (item == null)
            {
                return;
            }

            if (item.IsPurchased)
            {
                ProcessSelling(item);
            }
            else
            {
                ProcessPurchase(item);
            }

            confirmPurchaseView.Configure(item);
            confirmPurchaseView.Toggle(true);
        }

        private void ProcessSelling(ShopItemSO item)
        {
            confirmPurchaseView.Configure(item);
            confirmPurchaseView.Toggle(true);
            confirmPurchaseView.OnConfirmed += CompleteSelling;
        }

        private void ProcessPurchase(ShopItemSO item)
        {
            if (item.Price > currenciesController.GetCurrencyValue(item.CurrencyToUse))
            {
                return;
            }

            confirmPurchaseView.Configure(item);
            confirmPurchaseView.Toggle(true);
            confirmPurchaseView.OnConfirmed += CompletePurchase;
        }

        private void CompletePurchase(ShopItemSO item)
        {
            currenciesController.SubstractCurrency(item.CurrencyToUse, item.Price);
            item.IsPurchased = true;
            confirmPurchaseView.Toggle(false);
            confirmPurchaseView.OnConfirmed -= CompletePurchase;
        }

        private void CompleteSelling(ShopItemSO item)
        {
            currenciesController.AddCurrency(item.CurrencyToUse, item.SellingPrice);
            item.IsPurchased = false;
            confirmPurchaseView.Toggle(false);
            confirmPurchaseView.OnConfirmed -= CompleteSelling;
        }

        private void TriggerShop()
        {
            view.Toggle(true);
        }

        private ShopItemSO GetShopItem(string id)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Item.Id == id)
                {
                    return items[i];
                }
            }

            Debug.LogError("Failed to find shop item of id " + id);
            return null;
        }
    }
}