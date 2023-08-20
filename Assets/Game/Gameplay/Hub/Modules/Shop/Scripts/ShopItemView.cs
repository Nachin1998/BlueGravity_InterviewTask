using System;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace BlueGravity.Game.Hub.Modules.Shop
{
    public class ShopItemView : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private Button purchaseButton = null;
        [SerializeField] private Transform priceHolder = null;
        [SerializeField] private TMP_Text titleText = null;
        [SerializeField] private TMP_Text priceText = null;
        [SerializeField] private Image itemIcon = null;
        [SerializeField] private Image currencyIcon = null;

        private string id = string.Empty;
        private int price = 0;
        private bool isPurchased = false;

        public string Id { get => id; }
        public int Price { get => price; }
        public bool IsPurchased { get => isPurchased; }

        public void Init(Action<ShopItemView> onItemPressed)
        {
            purchaseButton.onClick.AddListener(() => onItemPressed?.Invoke(this));
        }

        public void Configure(ShopItemSO item)
        {
            id = item.Id;
            price = item.Price;
            itemIcon.sprite = item.Item.Icon;

            isPurchased = item.IsPurchased;

            SetPrice(item);
            itemIcon.transform.localScale = new Vector3(item.ViewSize, item.ViewSize);
            titleText.text = id;
        }

        private void SetPrice(ShopItemSO item)
        {
            if (!item.IsPurchased)
            {
                priceText.text = item.Price.ToString();
            }
            else
            {
                priceText.text = "Sell " + item.SellingPrice.ToString();
            }

            currencyIcon.sprite = item.CurrencyType.Icon;
        }

        public void Toggle(bool status)
        {
            gameObject.SetActive(status);
        }
    }
}