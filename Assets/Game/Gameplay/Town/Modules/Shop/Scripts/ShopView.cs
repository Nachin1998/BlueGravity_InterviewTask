using System;

using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace BlueGravity.Game.Town.Modules.Shop
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private Transform holder = null;
        [SerializeField] private Transform shopItemsHolder = null;
        [SerializeField] private Button closeButton = null;
        [SerializeField] private ShopItemView shopItemPrefab = null;

        public event Action<bool> OnShopToggled = null;
        public event Action<ShopItemView> OnItemPressed = null;
        public event Action OnItemPurchased = null;

        private ObjectPool<ShopItemView> shopItemPool = null;

        public void Init(ShopItemSO[] items)
        {
            shopItemPool = new ObjectPool<ShopItemView>(GenerateItem, GetItem, ReleaseItem);
            closeButton.onClick.AddListener(ClosePanel);

            for (int i = 0; i < items.Length; i++)
            {
                ShopItemView item = shopItemPool.Get();
                item.Configure(items[i]);
            }
        }

        private void ClosePanel()
        {
            Toggle(false);
        }

        public void Toggle(bool status)
        {
            holder.gameObject.SetActive(status);
            OnShopToggled?.Invoke(status);
        }

        private ShopItemView GenerateItem()
        {
            ShopItemView item = Instantiate(shopItemPrefab, shopItemsHolder);
            item.Init(OnItemPressed);
            return item;
        }

        private void GetItem(ShopItemView item)
        {
            item.gameObject.SetActive(true);
        }

        private void ReleaseItem(ShopItemView item)
        {
            item.gameObject.SetActive(false);
        }
    }
}