using System;

using UnityEngine;

using BlueGravity.Common.Characters;
using BlueGravity.Common.Interaction;

namespace BlueGravity.Common.NPC
{
    public class NPCCharacterView : SpriteCharacterView, IInteractable
    {
        [field: SerializeField] public GameObject popup { get; set; } = null;

        public event Action OnInteracted;

        public void Interact()
        {
            OnInteracted?.Invoke();
        }
    }
}