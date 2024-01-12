using System;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace BlueGravity.Game.Town.Modules.Shop
{
    public class ConfirmPurchaseView : MonoBehaviour
    {
        #region EXPOSED_FIELDS
        [Header("Main Configuration")]
        [SerializeField] private Transform holder = null;
        [SerializeField] private TMP_Text itemIdText = null;
        [SerializeField] private Button confirmButton = null;
        [SerializeField] private Button cancelButton = null;
        #endregion

        #region PRIVATE_FIELDS
        private ShopItemSO currentItem = null;
        #endregion

        #region ACTIONS
        public event Action<ShopItemSO> OnConfirmed = null;
        public event Action OnCanceled = null;
        #endregion

        #region PUBLIC_METHODS
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
        #endregion

        #region PRIVATE_METHODS
        private void Confirm()
        {
            OnConfirmed?.Invoke(currentItem);
        }

        private void Cancel()
        {
            Toggle(false);
            OnCanceled?.Invoke();
        }
        #endregion
    }
}