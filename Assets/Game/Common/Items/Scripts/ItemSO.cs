using UnityEngine;

namespace BlueGravity.Common.Items
{
    [CreateAssetMenu(fileName = "item_", menuName = "ScriptableObjects/Common/Items/Default Item")]
    public class ItemSO : ScriptableObject
    {
        [Header("Main Configuration")]
        [SerializeField] private string id = string.Empty;
        [SerializeField] private Sprite icon = null;

        public string Id { get => id; }
        public Sprite Icon { get => icon; }
    }
}