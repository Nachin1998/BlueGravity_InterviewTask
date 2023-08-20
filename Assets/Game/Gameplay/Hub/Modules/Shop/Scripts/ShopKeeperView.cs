using System;

using UnityEngine;

using BlueGravity.Common.Audio;
using BlueGravity.Common.Interaction;

namespace BlueGravity.Game.Hub.Modules.Shop
{
    public class ShopKeeperView : MonoBehaviour, IInteractable
    {
        [Header("Main Configuration")]
        [SerializeField] private InteractionArea interactionArea = null;
        [SerializeField] private GameObject speechBubble = null;

        [Header("Audio Configuration")]
        [SerializeField] private AudioChannel audioChannel = null;
        [SerializeField] private AudioSO popupSFX = null;

        private bool isInteractable = true;
        private Action OnInteracted = null;

        public void Init(Action onInteracted, Action onCustomerInRange, Action onCustomerLeave)
        {
            OnInteracted = onInteracted;
            interactionArea.Init(
                onTriggerEnter: (obj) =>
                {
                    if (obj.TryGetComponent(out IShopCustomer customer))
                    {
                        ProcessInteraction(true);
                        onCustomerInRange?.Invoke();
                    }
                },
                onTriggerExit: (obj) =>
                {
                    if (obj.TryGetComponent(out IShopCustomer customer))
                    {
                        ProcessInteraction(false);
                        onCustomerLeave?.Invoke();
                    }
                });
        }

        private void ProcessInteraction(bool isInRange)
        {
            if (isInRange)
            {
                audioChannel.OnTriggerSFX?.Invoke(popupSFX);
            }

            speechBubble.SetActive(isInRange);
            isInteractable = isInRange;
        }

        public void Interact()
        {
            if (isInteractable)
            {
                OnInteracted?.Invoke();
            }
        }

        public void ToggleIsInteractable(bool status)
        {
            isInteractable = status;
        }
    }
}