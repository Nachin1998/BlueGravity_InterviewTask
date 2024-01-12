using System.Collections.Generic;

using UnityEngine;

using BlueGravity.Common.Controller;
using BlueGravity.Common.Currencies;
using BlueGravity.Common.Items;
using BlueGravity.Common.Items.BodyParts;
using BlueGravity.Common.Player;

using BlueGravity.Game.Town.Modules.CharacterCustomization;
using BlueGravity.Game.Town.Modules.Shop;

namespace BlueGravity.Game.Town.Controller
{
    public class TownController : SceneController
    {
        #region EXPOSED_FIELDS
        [Header("Town Configuration")]
        [SerializeField] private PlayerController playerController = null;
        [SerializeField] private ShopController shopController = null;
        [SerializeField] private CurrenciesController currenciesController = null;
        [SerializeField] private CharacterCustomizationController characterCustomizationController = null;
        [SerializeField] private ItemsHandler itemsHandler = null;
        #endregion

        #region PROTECTED_METHODS
        protected override void Init()
        {
            currenciesController.Init();

            shopController.OnShopToggled += SwitchPlayerInteraction;
            shopController.OnItemSold += TryRemovePlayerPart;
            shopController.OnItemSold += (item) => RefreshCustomizationController();
            shopController.OnItemPurchased += (item) => RefreshCustomizationController();
            shopController.Init();

            characterCustomizationController.OnPanelToggled += SwitchPlayerInteraction;
            characterCustomizationController.Init();
            RefreshCustomizationController();
        }
        #endregion

        #region PRIVATE_METHODS
        private void SwitchPlayerInteraction(bool status)
        {
            playerController.ToggleInteraction(!status);
        }

        private void TryRemovePlayerPart(ItemSO item)
        {
            if (item is BodyPartItemSO bodyPartItem)
            {
                playerController.TryRemovePart(bodyPartItem);
            }
        }

        private void RefreshCustomizationController()
        {
            characterCustomizationController.RefreshItems(GetDisplayableItems());
        }

        private List<BodyPartItemSO> GetDisplayableItems()
        {
            List<BodyPartItemSO> toReturn = new List<BodyPartItemSO>();
            List<BodyPartItemSO> items = itemsHandler.GetItems<BodyPartItemSO>();
            List<ShopItemSO> shopItems = shopController.GetItems();

            for (int i = 0; i < items.Count; i++)
            {
                ShopItemSO shopItem = shopItems.Find((item) => item.Item == items[i]);

                bool isInShopCatalog = shopItem != null;
                if (!isInShopCatalog)
                {
                    toReturn.Add(items[i]);
                    continue;
                }

                if (shopItem.IsPurchased)
                {
                    toReturn.Add(items[i]);
                }
            }

            return toReturn;
        }
        #endregion
    }
}