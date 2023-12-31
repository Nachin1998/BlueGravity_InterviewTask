using UnityEngine;

namespace BlueGravity.Common.Items.Body
{
    public enum BODY_PART
    {
        INVALID = -1,
        ACCESSORY,
        HAIR,
        COSTUME
    }

    [CreateAssetMenu(fileName = "costume_item_", menuName = "ScriptableObjects/Common/Items/Costume Item")]
    public class BodyPartItemSO : ItemSO
    {
        [Header("Body Part configuration")]
        [SerializeField] private RuntimeAnimatorController animatorController = null;
        [SerializeField] private BODY_PART part = BODY_PART.INVALID;

        public RuntimeAnimatorController AnimatorController { get => animatorController; }
        public BODY_PART Part { get => part; }
    }
}