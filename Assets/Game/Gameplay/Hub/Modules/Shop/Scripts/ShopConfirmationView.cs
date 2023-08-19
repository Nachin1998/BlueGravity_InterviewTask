using System;

using UnityEngine;
using UnityEngine.UI;

public class ShopConfirmationView : MonoBehaviour
{
    [SerializeField] private Button confirmButton = null;
    [SerializeField] private Button cancelButton = null;

    private string itemId = string.Empty;

    public void Init(Action<string> onConfirm)
    {
        confirmButton?.onClick.AddListener(() => onConfirm?.Invoke(itemId));
    }

    public void Toggle(bool status)
    {

    }

    public void Configure(ShopItemView view)
    {
        itemId = view.Id;
    }
}
