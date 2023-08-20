using UnityEngine;

using BlueGravity.Common.Controller;
using BlueGravity.Common.Player;
using BlueGravity.Common.Items.Body;

using BlueGravity.Game.Hub.Modules.Shop;
using BlueGravity.Game.Hub.Modules.Currencies;
using BlueGravity.Game.Hub.Modules.Customization;

namespace BlueGravity.Game.Hub.Controller
{
    public class HubController : SceneController
    {
        [Header("Hub Controller Configuration")]
        [SerializeField] private PlayerController playerController = null;
        [SerializeField] private GameCurrenciesController currenciesController = null;
        [SerializeField] private CameraController cameraController = null;
        [SerializeField] private ShopController shopController = null;
        [SerializeField] private CustomizationController customizationController = null;

        protected override void Init()
        {
            playerController.Init();
            currenciesController.Init();
            cameraController.SetTarget(playerController.transform);
            shopController.Init(null, TryRemovePlayerItemView);
            customizationController.Init();
        }

        protected override void OnEnable()
        {
        }

        protected override void OnDisable()
        {
            currenciesController.DeInit();
            shopController.DeInit();
        }

        private void TryRemovePlayerItemView(ShopItemSO item)
        {
            if (item.Item is BodyPartItemSO bodyItem)
            {
                playerController.RemovePart(bodyItem);
            }
        }
    }
}