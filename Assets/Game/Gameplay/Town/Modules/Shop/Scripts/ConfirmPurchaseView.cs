using System;

using UnityEngine;
using UnityEngine.UI;

using BlueGravity.Game.Town.Modules.Shop;

using TMPro;

namespace BlueGravity.Game.Town.Modules.Shop
{
    public class ConfirmPurchaseView : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private Transform holder = null;
        [SerializeField] private TMP_Text itemIdText = null;
        [SerializeField] private Button confirmButton = null;
        [SerializeField] private Button cancelButton = null;

        private ShopItemSO currentItem = null;

        public event Action<ShopItemSO> OnConfirmed = null;
        public event Action OnCanceled = null;

        public void Init()
        {
            confirmButton.onClick.AddListener(Confirm);
            cancelButton.onClick.AddListener(Cancel);
        }

        public void Toggle(bool status)
        {
            holder.gameObject.SetActive(status);
        }

        public void Configure(ShopItemSO view)
        {
            currentItem = view;
            itemIdText.text = view.Item.Id;
            Toggle(true);
        }

        private void Confirm()
        {
            OnConfirmed?.Invoke(currentItem);
        }

        private void Cancel()
        {
            Toggle(false);
            OnCanceled?.Invoke();
        }
    }
}