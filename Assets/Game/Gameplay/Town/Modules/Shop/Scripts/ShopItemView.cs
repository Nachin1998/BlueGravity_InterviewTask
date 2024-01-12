using System;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace BlueGravity.Game.Town.Modules.Shop
{
    public class ShopItemView : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private Button tryPurchaseButton = null;
        [SerializeField] private TMP_Text itemTitleText = null;
        [SerializeField] private TMP_Text itemPriceText = null;
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
            tryPurchaseButton.onClick.AddListener(() => onItemPressed.Invoke(this));
        }

        public void Configure(ShopItemSO item)
        {
            id = item.Item.Id;
            price = item.IsPurchased ? item.SellingPrice : item.Price;
            itemIcon.rectTransform.anchoredPosition = Vector2.zero;

            itemTitleText.text = id;
            itemPriceText.text = item.IsPurchased ? "Sell " + price.ToString() : price.ToString();
            itemIcon.sprite = item.Item.Icon;
            currencyIcon.sprite = item.CurrencyToUse.Icon;
            itemIcon.rectTransform.localScale = new Vector2(item.ItemSize, item.ItemSize);
            itemIcon.rectTransform.anchoredPosition = itemIcon.rectTransform.anchoredPosition - item.ItemPositionOffset;
        }

        public void SetPurchaseStatus(bool status)
        {
            isPurchased = status;
        }
    }
}