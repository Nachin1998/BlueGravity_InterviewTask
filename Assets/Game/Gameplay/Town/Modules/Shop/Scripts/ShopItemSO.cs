using UnityEngine;

using BlueGravity.Common.Items;
using BlueGravity.Common.Currencies;

namespace BlueGravity.Game.Town.Modules.Shop
{
    [CreateAssetMenu(fileName = "shopItem_", menuName = "ScriptableObjects/Town/Shop/Shop Item")]
    public class ShopItemSO : ScriptableObject
    {
        #region EXOPSED_FIELDS
        [Header("Main Configuration")]
        [SerializeField] private ItemSO item = null;

        [Header("Price Configuration")]
        [SerializeField] private CurrencySO currencyToUse = null;
        [SerializeField] private int price = 0;
        [SerializeField, Range(0, 100)] private int sellingPricePercentage = 100;
        
        [Header("Shop Item Frame Configuration")]
        [SerializeField] private int itemSize = 1;
        [SerializeField] private Vector2 itemPositionOffset = Vector2.zero;
        #endregion

        #region PROPERTIES
        public ItemSO Item { get => item; }
        public CurrencySO CurrencyToUse { get => currencyToUse; }
        public int Price { get => price; }
        public int SellingPrice { get => (price * sellingPricePercentage) / 100; }
        public int ItemSize { get => itemSize; }
        public Vector2 ItemPositionOffset { get => itemPositionOffset; }
        public bool IsPurchased { get; set; } = false;
        #endregion
    }
}