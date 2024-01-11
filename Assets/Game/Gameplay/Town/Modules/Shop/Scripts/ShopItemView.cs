using UnityEngine;
using UnityEngine.UI;

using TMPro;
using System.Diagnostics;
using System;

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

        public string Id { get => id; }
        public int Price { get => price; }

        public void Init(Action<ShopItemView> onItemPressed)
        {
            tryPurchaseButton.onClick.AddListener(() => onItemPressed.Invoke(this));
        }

        public void Configure(ShopItemSO item)
        {
            id = item.Item.Id;
            price = item.Price;

            itemTitleText.text = id;
            itemPriceText.text = price.ToString();
            itemIcon.sprite = item.Item.Icon;
            currencyIcon.sprite = null;
        }
    }
}