using System.Collections.Generic;

using UnityEngine;

using BlueGravity.Common.Items;

namespace BlueGravity.Game.Hub.Modules.Customization
{
    [CreateAssetMenu(fileName = "category_", menuName = "ScriptableObjects/Hub/Customization/Customization Category")]
    public class CategorySO : ScriptableObject
    {
        [Header("Main Configuration")]
        [SerializeField] private string id = string.Empty;
        [SerializeField] private List<ItemSO> items = null;

        public string Id { get => id; }
        public List<ItemSO> Items { get => items; }
        public List<ItemSO> UnlockedItems
        {
            get
            {
                List<ItemSO> list = new List<ItemSO>();

                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].IsUnlocked)
                    {
                        list.Add(items[i]);
                    }
                }

                return list;
            }
        }
    }
}