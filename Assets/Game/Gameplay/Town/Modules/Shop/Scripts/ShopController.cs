using UnityEngine;

using BlueGravity.Common.NPC;
using System;

namespace BlueGravity.Game.Town.Modules.Shop
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private ShopView view = null;
        [SerializeField] private ShopItemSO[] items = null;
        [SerializeField] private NPCCharacterView shopKeeper = null;

        public event Action<bool> OnShopToggled = null;

        public void Init()
        {
            shopKeeper.OnInteracted += TriggerShop;
            view.OnShopToggled += OnShopToggled;
            view.Init(items);
        }

        private void TriggerShop()
        {
            view.Toggle(true);
        }
    }
}