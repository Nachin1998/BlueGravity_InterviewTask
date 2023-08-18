using System;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText = null;
    [SerializeField] private TMP_Text priceText = null;
    [SerializeField] private Image icon = null;
    [SerializeField] private Button purchaseButton = null;

    private string id = string.Empty;
    private int price = 0;

    public string Id { get => id; }
    public int Price { get => price; }

    public void Init(Action<ShopItemView> onItemPressed)
    {
        purchaseButton.onClick.AddListener(() => onItemPressed?.Invoke(this));
    }

    public void Configure(string id, int price, Sprite iconSprite, bool isPurchased)
    {
        this.id = id;
        this.price = price;
        titleText.text = id;
        icon.sprite = iconSprite;

        purchaseButton.gameObject.SetActive(!isPurchased);
    }

    public void Toggle(bool status)
    {
        gameObject.SetActive(status);
    }
}
