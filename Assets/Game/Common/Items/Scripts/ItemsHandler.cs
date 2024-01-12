using System.Collections.Generic;

using UnityEngine;

namespace BlueGravity.Common.Items
{
    public class ItemsHandler : MonoBehaviour
    {
        #region EXPOSED_FIELDS
        [Header("Main Configuration")]
        [SerializeField] private List<ItemSO> items = null;
        #endregion

        #region PUBLIC_METHODS
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
        #endregion
    }
}