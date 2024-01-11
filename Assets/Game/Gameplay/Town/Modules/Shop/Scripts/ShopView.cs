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

        public event Action OnCloseButtonPressed = null;
        public event Action OnItemPressed = null;
        public event Action OnItemPurchased = null;

        private ObjectPool<ShopItemView> shopItemPool = null;

        public void Init()
        {
            shopItemPool = new ObjectPool<ShopItemView>(GenerateItem, GetItem, ReleaseItem);
            closeButton.onClick.AddListener(ClosePanel);
        }

        private void ClosePanel()
        {
            Toggle(false);
            OnCloseButtonPressed?.Invoke();
        }

        public void Toggle(bool status)
        {
            holder.gameObject.SetActive(status);
        }

        private ShopItemView GenerateItem()
        {
            ShopItemView item = Instantiate(shopItemPrefab, shopItemsHolder);
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