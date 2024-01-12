using System;

using UnityEngine;

using BlueGravity.Common.Characters;
using BlueGravity.Common.Interaction;

namespace BlueGravity.Common.NPC
{
    public class NPCCharacterView : SpriteCharacterView, IInteractable
    {
        #region EXPOSED_FIELDS
        [field: SerializeField] public GameObject popup { get; set; } = null;
        #endregion

        #region ACTIONS
        public event Action OnInteracted;
        #endregion

        #region PUBLIC_METHODS
        public void Interact()
        {
            OnInteracted?.Invoke();
        }
        #endregion
    }
}