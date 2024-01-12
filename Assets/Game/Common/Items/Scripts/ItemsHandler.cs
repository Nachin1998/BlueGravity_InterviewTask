using System.Collections.Generic;

using UnityEngine;

namespace BlueGravity.Common.Items
{
    public class ItemsHandler : MonoBehaviour
    {
        [SerializeField] private List<ItemSO> items = null;

        public List<T> GetItems<T>() where T : ItemSO
        {
            List<T> toReturn = new List<T>();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] is T castedItem)
                {
                    toReturn.Add(castedItem);
                }
            }

            return toReturn;
        }

        public T GetItem<T>(string id) where T : ItemSO
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == id)
                {
                    return items[i] as T;
                }
            }

            return null;
        }
    }
}