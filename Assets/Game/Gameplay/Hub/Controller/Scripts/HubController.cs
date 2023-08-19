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
        [SerializeField] private CurrenciesController currenciesController = null;
        [SerializeField] private CameraController cameraController = null;
        [SerializeField] private ShopController shopController = null;

        protected override void Awake()
        {
            currenciesController.Init();
            cameraController.SetTarget(playerController.transform);
            shopController.Init();
        }

        protected override void OnDisable()
        {
        }

        protected override void OnEnable()
        {
        }
    }
}