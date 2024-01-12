using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace BlueGravity.Common.Currencies
{
    public class CurrencyItemView : MonoBehaviour
    {
        #region EXPOSED_FIELDS
        [Header("Main Configuration")]
        [SerializeField] private Transform holder = null;
        [SerializeField] private Image icon = null;
        [SerializeField] private TMP_Text amountText = null;
        #endregion

        #region PRIVATE_FIELDS
        private string id = string.Empty;
        #endregion

        #region PROPERTIES
        public string Id { get => id; }
        #endregion

        #region PUBLIC_METHODS
        public void Configure(CurrencySO currency, CurrencyModel model)
        {
            id = currency.Id;
            SetValue(model.Value);
            icon.sprite = currency.Icon;
        }

        public void SetValue(int value)
        {
            amountText.text = value.ToString();
        }

        public void Toggle(bool status)
        {
            holder.gameObject.SetActive(status);
        }
        #endregion
    }
}