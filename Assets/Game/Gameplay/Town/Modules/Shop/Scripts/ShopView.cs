using System;
using System.Collections.Generic;
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
        private List<ShopItemView> shopItems = null;

        public void Init(List<ShopItemSO> items)
        {
            shopItemPool = new ObjectPool<ShopItemView>(GenerateItem, GetItem, ReleaseItem);
            shopItems = new List<ShopItemView>();
            closeButton.onClick.AddListener(ClosePanel);

            for (int i = 0; i < items.Count; i++)
            {
                ShopItemView item = shopItemPool.Get();
                item.Configure(items[i]);
                shopItems.Add(item);
            }
        }

        public ShopItemView GetView(string id)
        {
            for (int i = 0;i < shopItems.Count;i++)
            {
                if (shopItems[i].Id == id)
                {
                    return shopItems[i];
                }
            }

            Debug.LogError("Failed to find view of id " + id);
            return null;
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