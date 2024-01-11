using System;

using UnityEngine;

namespace BlueGravity.Common.Interaction
{
    public interface IInteractable
    {
        public GameObject popup { get; set; }

        public event Action OnInteracted;

        public void TogglePopup(bool status)
        {
            popup.SetActive(status);
        }

        public void Interact();
    }
}