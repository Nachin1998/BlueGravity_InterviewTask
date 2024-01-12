using System;
using System.Collections.Generic;

using UnityEngine;

using BlueGravity.Common.NPC;
using BlueGravity.Common.Currencies;
using BlueGravity.Common.Items;
using BlueGravity.Common.Audio;

namespace BlueGravity.Game.Town.Modules.Shop
{
    public class ShopController : MonoBehaviour
    {
        #region EXPOSED_FIELDS
        [Header("Main Configuration")]
        [SerializeField] private ShopView view = null;
        [SerializeField] private ConfirmPurchaseView confirmPurchaseView = null;
        [SerializeField] private CurrenciesController currenciesController = null;
        [SerializeField] private List<ShopItemSO> items = null;
        [SerializeField] private NPCCharacterView shopKeeper = null;

        [Header("Audio Configuration")]
        [SerializeField] private AudioChannel audioChannel = null;
        [SerializeField] private AudioSO transactionSFX = null;
        #endregion

        #region ACTIONS
        public event Action<bool> OnShopToggled = null;
        public event Action<ItemSO> OnItemSold = null;
        public event Action<ItemSO> OnItemPurchased = null;
        #endregion

        #region PUBLIC_METHODS
        public void Init()
        {
            shopKeeper.OnInteracted += TriggerShop;
            view.OnShopToggled += OnShopToggled;
            view.OnShopToggled += ToggleConfirmationPanelOff;
            view.OnItemPressed += ProcessItem;
            view.Init(items);

            confirmPurchaseView.Init();
        }

        public List<ShopItemSO> GetItems()
        {
            return items;
        }
        #endregion

        #region PRIVATE_METHODS
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
            OnItemPurchased?.Invoke(item.Item);
            audioChannel.TriggerSFX(transactionSFX);
            confirmPurchaseView.Toggle(false);
            view.GetView(item.Item.Id).Configure(item);
            confirmPurchaseView.OnConfirmed -= CompletePurchase;
        }

        private void CompleteSelling(ShopItemSO item)
        {
            currenciesController.AddCurrency(item.CurrencyToUse, item.SellingPrice);
            item.IsPurchased = false;
            confirmPurchaseView.Toggle(false);
            OnItemSold?.Invoke(item.Item);
            audioChannel.TriggerSFX(transactionSFX);
            view.GetView(item.Item.Id).Configure(item);
            confirmPurchaseView.OnConfirmed -= CompleteSelling;
        }

        private void TriggerShop()
        {
            view.Toggle(true);
        }

        private void ToggleConfirmationPanelOff(bool status)
        {
            if (!status)
            {
                confirmPurchaseView.Toggle(status);
            }
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

            Debug.LogError("Failed to find shop item of id " + id);
            return null;
        }
        #endregion
    }
}