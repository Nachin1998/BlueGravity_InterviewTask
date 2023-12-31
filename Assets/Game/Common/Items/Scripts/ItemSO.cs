using UnityEngine;

namespace BlueGravity.Common.Items
{
    [CreateAssetMenu(fileName = "item_", menuName = "ScriptableObjects/Common/Items/Generic Item")]
    public class ItemSO : ScriptableObject
    {
        [Header("Main Configuration")]
        [SerializeField] private string id = string.Empty;
        [SerializeField] private Sprite icon = null;
        [SerializeField] private bool isUnlocked = false; //serialized for debugging purposes

        public string Id { get => id; }
        public Sprite Icon { get => icon; }
        public bool IsUnlocked { get => isUnlocked; }

        public void ToggleIsUnlocked(bool status)
        {
            isUnlocked = status;
        }
    }
}