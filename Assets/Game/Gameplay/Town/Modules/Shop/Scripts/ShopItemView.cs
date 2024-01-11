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

        public void Configure(string id, string price, Sprite icon, Sprite currency)
        {
            itemTitleText.text = id;
            itemPriceText.text = price;
            itemIcon.sprite = icon;
            currencyIcon.sprite = currency;
        }
    }
}