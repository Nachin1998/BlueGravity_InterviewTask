using UnityEngine;

using BlueGravity.Common.Controller;
using BlueGravity.Common.Currencies;
using BlueGravity.Common.Player;

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

        protected override void Awake()
        {
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
            SpriteCharacterView view = playerController.GetComponent<SpriteCharacterView>();

            for (int i = 0; i < view.Parts; i++)
            {
                if (view[i] == item.Item.Icon)
                {
                    view[i] = null;
                }
            }
        }
    }
}