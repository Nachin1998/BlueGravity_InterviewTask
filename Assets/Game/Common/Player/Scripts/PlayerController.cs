using UnityEngine;

using BlueGravity.Common.Items.BodyParts;

namespace BlueGravity.Common.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerView view = null;

        public void ToggleInteraction(bool status)
        {
            view.ToggleInteraction(status);
        }

        public void TryRemovePart(BodyPartItemSO part)
        {
            view.RemovePart(part);
        }
    }
}