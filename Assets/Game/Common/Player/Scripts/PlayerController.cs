using UnityEngine;

using BlueGravity.Common.Items.BodyParts;

namespace BlueGravity.Common.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region EXPOSED_FIELDS
        [Header("Main Configuration")]
        [SerializeField] private PlayerView view = null;
        #endregion

        #region PUBLIC_METHODS
        public void ToggleInteraction(bool status)
        {
            view.ToggleInteraction(status);
        }

        public void TryRemovePart(BodyPartItemSO part)
        {
            view.RemovePart(part);
        }
        #endregion
    }
}