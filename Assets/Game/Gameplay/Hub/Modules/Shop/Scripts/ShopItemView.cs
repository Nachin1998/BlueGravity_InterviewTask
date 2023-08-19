using System;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private Button purchaseButton = null;
    [SerializeField] private Transform priceHolder = null;
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
        purchaseButton.interactable = !item.IsPurchased;
        SetPrice(item);
        itemIcon.transform.localScale = new Vector3(item.ViewSize, item.ViewSize);
        titleText.text = id;
    }

    private void SetPrice(ShopItemSO item)
    {
        currencyIcon.enabled = !item.IsPurchased;

        if (!item.IsPurchased)
        {
            priceText.text = item.Price.ToString();
            currencyIcon.sprite = item.CurrencyType.Icon;
        }
        else
        {
            priceText.text = "Purchased";
        }
    }

    public void Toggle(bool status)
    {
        gameObject.SetActive(status);
    }
}
