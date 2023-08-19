using System;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private Button purchaseButton = null;
    [SerializeField] private TMP_Text titleText = null;
    [SerializeField] private TMP_Text priceText = null;
    [SerializeField] private Image itemIcon = null;
    [SerializeField] private Image currencyIcon = null;

    private string id = string.Empty;
    private int price = 0;

    public string Id { get => id; }
    public int Price { get => price; }

    public void Init(Action<ShopItemView> onItemPressed)
    {
        purchaseButton.onClick.AddListener(() => onItemPressed?.Invoke(this));
    }

    public void Configure(ShopItemSO item)
    {
        id = item.Id;
        price = item.Price;
        itemIcon.sprite = item.Item.Icon;
        priceText.text = item.Price.ToString();
        purchaseButton.interactable = !item.IsPurchased;
        currencyIcon.sprite = item.CurrencyType.Icon;

        titleText.text = id;
    }

    public void Toggle(bool status)
    {
        gameObject.SetActive(status);
    }
}
