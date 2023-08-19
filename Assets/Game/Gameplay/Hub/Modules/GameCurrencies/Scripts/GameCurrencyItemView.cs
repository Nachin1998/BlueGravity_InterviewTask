using UnityEngine;
using UnityEngine.UI;
using BlueGravity.Common.Currencies;
using TMPro;

public class GameCurrencyItemView : MonoBehaviour
{
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
