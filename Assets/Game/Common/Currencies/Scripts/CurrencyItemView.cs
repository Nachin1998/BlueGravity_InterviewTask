using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace BlueGravity.Common.Currencies
{
    public class CurrencyItemView : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private Transform holder = null;
        [SerializeField] private Image icon = null;
        [SerializeField] private TMP_Text amountText = null;

        private string id = string.Empty;

        public string Id { get => id; }

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
    }
}