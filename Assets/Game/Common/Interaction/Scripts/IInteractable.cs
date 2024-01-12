using System;

using UnityEngine;

namespace BlueGravity.Common.Interaction
{
    public interface IInteractable
    {
        #region PROPERTIES
        public GameObject popup { get; set; }
        #endregion

        #region ACTIONS
        public event Action OnInteracted;
        #endregion

        #region PUBLIC_METHODS
        public void TogglePopup(bool status)
        {
            popup.SetActive(status);
        }

        public void Interact();
        #endregion
    }
}