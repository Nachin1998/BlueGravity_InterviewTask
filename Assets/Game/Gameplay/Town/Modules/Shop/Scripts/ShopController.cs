using BlueGravity.Common.NPC;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace BlueGravity.Game.Town.Modules.Shop
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private ShopView view = null;
        [SerializeField] private ShopItemSO[] items = null;
        [SerializeField] private NPCCharacterView shopKeeper = null;

        public void Init()
        {
            shopKeeper.OnInteracted += OpenPanel;

            view.Init();
        }

        private void OpenPanel()
        {
            view.Toggle(true);
        }
    }
}