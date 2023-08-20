using System.Collections.Generic;

using UnityEngine;

using BlueGravity.Common.Items.Body;

namespace BlueGravity.Game.Hub.Modules.Customization
{
    [CreateAssetMenu(fileName = "category_", menuName = "ScriptableObjects/Hub/Customization/Customization Category")]
    public class CategorySO : ScriptableObject
    {
        [Header("Main Configuration")]
        [SerializeField] private string id = string.Empty;
        [SerializeField] private List<BodyPartItemSO> items = null;

        public string Id { get => id; }
        public List<BodyPartItemSO> Items { get => items; }
        public List<BodyPartItemSO> UnlockedItems
        {
            get
            {
                List<BodyPartItemSO> list = new List<BodyPartItemSO>();

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