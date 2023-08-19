using UnityEngine;

using BlueGravity.Common.Currencies;

[CreateAssetMenu(fileName = "shopitem_", menuName = "ScriptableObjects/Hub/Shop/Shop item")]
public class ShopItemSO : ScriptableObject
{
    [Header("Main Configuration")]
    [SerializeField] private ItemSO item = null;
    [SerializeField] private float viewSize = 1; //patch mainly because all the art is different with different sizes

    [Header("Price Configuration")]
    [SerializeField] private CurrencySO currencyType = null;
    [SerializeField] private int price = 0;

    private bool isPurchased = false;

    public string Id { get => item.Id; }
    public ItemSO Item { get => item; }
    public CurrencySO CurrencyType { get => currencyType; }
    public int Price { get => price; }
    public bool IsPurchased { get => isPurchased; }
    public float ViewSize { get => viewSize; }

    public void SetIsPurchased(bool status)
    {
        isPurchased = status;
    }
}