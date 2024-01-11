using UnityEngine;

using BlueGravity.Common.Items;

namespace BlueGravity.Game.Town.Modules.Shop
{
    [CreateAssetMenu(fileName = "shopItem_", menuName = "ScriptableObjects/Town/Shop/Shop Item")]
    public class ShopItemSO : ScriptableObject
    {
        [SerializeField] private ItemSO item = null;
        [SerializeField] private int price = 0;
        [SerializeField][Range(0, 100)] private int sellingPriceReductionPercentage = 100;

        public ItemSO Item { get => item; }
        public int Price { get => price; }
        public int SellingPriceReductionPercentage { get => sellingPriceReductionPercentage; }
    }
}