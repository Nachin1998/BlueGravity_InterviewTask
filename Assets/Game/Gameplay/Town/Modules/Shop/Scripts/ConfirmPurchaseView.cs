using BlueGravity.Game.Town.Modules.Shop;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPurchaseView : MonoBehaviour
{
    [Header("Main Configuration")]
    [SerializeField] private Transform holder = null;
    [SerializeField] private TMP_Text itemIdText = null;
    [SerializeField] private Button confirmButton = null;
    [SerializeField] private Button cancelButton = null;

    private ShopItemView itemView = null;

    public void Init(Action<ShopItemView> onConfirm)
    {
        confirmButton.onClick.AddListener(() => onConfirm?.Invoke(itemView));
        cancelButton.onClick.AddListener(() => Toggle(false));
    }

    public void Toggle(bool status)
    {
        holder.gameObject.SetActive(status);
    }

    public void Configure(ShopItemView view)
    {
        itemView = view;
        itemIdText.text = view.Id;
        Toggle(true);
    }
}
