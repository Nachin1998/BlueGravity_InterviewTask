using UnityEngine;

namespace BlueGravity.Common.Items.BodyParts
{
    #region ENUMS
    public enum BODY_PART
    {
        INVALID = -1,
        ACCESSORY,
        HAIR,
        COSTUME,
        MAX
    }
    #endregion

    [CreateAssetMenu(fileName = "costume_item_", menuName = "ScriptableObjects/Common/Items/Body Part Item")]
    public class BodyPartItemSO : ItemSO
    {
        #region EXPOSED_FIELDS
        [Header("Body Part configuration")]
        [SerializeField] private RuntimeAnimatorController animatorController = null;
        [SerializeField] private BODY_PART part = BODY_PART.INVALID;
        #endregion

        #region PROPERTIES
        public RuntimeAnimatorController AnimatorController { get => animatorController; }
        public BODY_PART Part { get => part; }
        #endregion
    }
}