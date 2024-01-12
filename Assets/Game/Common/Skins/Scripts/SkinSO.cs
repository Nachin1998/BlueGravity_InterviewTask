using UnityEngine;

using BlueGravity.Common.Items.BodyParts;

namespace BlueGravity.Common.Skins
{
    [CreateAssetMenu(fileName = "skin_", menuName = "ScriptableObjects/Common/Skins/Skin")]
    public class SkinSO : ScriptableObject
    {
        [SerializeField] private BodyPartItemSO accessoryItem = null;
        [SerializeField] private BodyPartItemSO hairItem = null;
        [SerializeField] private BodyPartItemSO costumeItem = null;

        public BodyPartItemSO AccessoryItem { get => accessoryItem; }
        public BodyPartItemSO HairItem { get => hairItem;}
        public BodyPartItemSO CostumeItem { get => costumeItem; }

        public bool HasBodyPart(BodyPartItemSO item)
        {
            return item == accessoryItem || item == hairItem || item == costumeItem;
        }

        public void RemoveBodyPart(BODY_PART part)
        {
            switch (part)
            {
                case BODY_PART.ACCESSORY:
                    accessoryItem = null;
                    break;

                case BODY_PART.HAIR:
                    hairItem = null;
                    break;

                case BODY_PART.COSTUME:
                    costumeItem = null;
                    break;
            }
        }
    }
}