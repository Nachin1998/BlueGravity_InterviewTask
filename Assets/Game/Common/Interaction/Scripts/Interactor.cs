using UnityEngine;

using BlueGravity.Common.Audio;

namespace BlueGravity.Common.Interaction
{
    [RequireComponent(typeof(InteractionArea))]
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private KeyCode interactionKey = KeyCode.E;
        [SerializeField] private InteractionArea interactionArea = null;
        [SerializeField] private AudioChannel audioChannel = null;
        [SerializeField] private AudioSO popupSfx = null;

        private IInteractable currentInteractable = null;

        private void Awake()
        {
            interactionArea = interactionArea != null ? interactionArea : GetComponent<InteractionArea>();
            interactionArea.OnTriggerEnter += RecieveInteractable;
            interactionArea.OnTriggerExit += RemoveInteractable;
        }

        private void Update()
        {
            if (Input.GetKeyDown(interactionKey))
            {
                currentInteractable?.Interact();
            }
        }

        private void RecieveInteractable(GameObject obj)
        {
            if (obj.TryGetComponent(out IInteractable interactable))
            {
                currentInteractable = interactable;
                currentInteractable.TogglePopup(true);
                audioChannel.TriggerSFX(popupSfx);
            }
        }

        private void RemoveInteractable(GameObject obj)
        {
            if (obj.TryGetComponent(out IInteractable interactable))
            {
                if (currentInteractable != null && currentInteractable == interactable)
                {
                    currentInteractable.TogglePopup(false);
                    currentInteractable = null;
                }
            }
        }
    }
}