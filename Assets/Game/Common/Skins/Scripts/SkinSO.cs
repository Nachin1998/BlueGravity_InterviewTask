using UnityEngine;

using BlueGravity.Common.Items.BodyParts;

namespace BlueGravity.Common.Skins
{
    [CreateAssetMenu(fileName = "skin_", menuName = "ScriptableObjects/Common/Skins/Skin")]
    public class SkinSO : ScriptableObject
    {
        #region EXPOSED_FIELDS
        [Header("Main Configuration")]
        [SerializeField] private BodyPartItemSO accessoryItem = null;
        [SerializeField] private BodyPartItemSO hairItem = null;
        [SerializeField] private BodyPartItemSO costumeItem = null;
        #endregion

        #region PROPERTIES
        public BodyPartItemSO AccessoryItem { get => accessoryItem; }
        public BodyPartItemSO HairItem { get => hairItem;}
        public BodyPartItemSO CostumeItem { get => costumeItem; }
        #endregion
    }
}