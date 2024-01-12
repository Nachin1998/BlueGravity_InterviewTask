using UnityEngine;

using BlueGravity.Game.Town.Modules.CharacterCustomization;
using BlueGravity.Game.Town.Modules.Shop;
using BlueGravity.Common.Currencies;
using BlueGravity.Common.Items;
using BlueGravity.Common.Items.BodyParts;

namespace BlueGravity.Game.Town.Controller
{
    public class TownController : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController = null;
        [SerializeField] private ShopController shopController = null;
        [SerializeField] private CurrenciesController currenciesController = null;
        [SerializeField] private CharacterCustomizationController characterCustomizationController = null;

        private void Start()
        {
            shopController.OnShopToggled += SwitchPlayerInteraction;
            shopController.OnItemSold += TryRemovePlayerPart;
            shopController.Init();
            currenciesController.Init();
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
    }
}