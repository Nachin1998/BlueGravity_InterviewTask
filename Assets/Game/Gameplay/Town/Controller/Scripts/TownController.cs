using System.Collections.Generic;

using UnityEngine;

using BlueGravity.Common.Currencies;
using BlueGravity.Common.Items;
using BlueGravity.Common.Items.BodyParts;

using BlueGravity.Game.Town.Modules.CharacterCustomization;
using BlueGravity.Game.Town.Modules.Shop;
using BlueGravity.Common.Audio;

namespace BlueGravity.Game.Town.Controller
{
    public class TownController : MonoBehaviour
    {
        [SerializeField] private AudioController audioController = null;
        [SerializeField] private AudioChannel audioChannel = null;
        [SerializeField] private AudioSO music = null;

        [SerializeField] private PlayerController playerController = null;
        [SerializeField] private ShopController shopController = null;
        [SerializeField] private CurrenciesController currenciesController = null;
        [SerializeField] private CharacterCustomizationController characterCustomizationController = null;
        [SerializeField] private ItemsHandler itemsHandler = null;

        private void Awake()
        {
            audioController.Init();

            audioChannel.TriggerMusic(music);

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
                bool isInShopCatalog = false;

                for (int j = 0; j < shopItems.Count; j++)
                {
                    if (items[i] == shopItems[j].Item)
                    {
                        isInShopCatalog = true;
                        if (shopItems[j].IsPurchased)
                        {
                            toReturn.Add(items[i]);
                        }
                        break;
                    }
                }

                if (!isInShopCatalog)
                {
                    toReturn.Add(items[i]);
                }
            }

            return toReturn;
        }
    }
}