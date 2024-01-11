using UnityEngine;

using BlueGravity.Game.Town.Modules.CharacterCustomization;
using BlueGravity.Game.Town.Modules.Shop;

namespace BlueGravity.Game.Town.Controller
{
    public class TownController : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController = null;
        [SerializeField] private ShopController shopController = null;
        [SerializeField] private CharacterCustomizationController characterCustomizationController = null;

        private void Start()
        {
            shopController.OnShopToggled += SwitchPlayerInteraction;
            shopController.Init();
        }

        private void Update()
        {

        }

        private void SwitchPlayerInteraction(bool status)
        {
            playerController.ToggleInteraction(!status);
        }
    }
}