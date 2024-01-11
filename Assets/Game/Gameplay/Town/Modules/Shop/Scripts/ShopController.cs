using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace BlueGravity.Game.Town.Modules.Shop
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private ShopView view = null;
        [SerializeField] private ShopItemSO[] items = null;

        public void Init()
        {
            view.Init();
        }

        private void Update()
        {

        }
    }
}