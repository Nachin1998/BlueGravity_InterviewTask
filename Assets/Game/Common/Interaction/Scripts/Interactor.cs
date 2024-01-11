using UnityEngine;

namespace BlueGravity.Common.Interaction
{
    [RequireComponent(typeof(InteractionArea))]
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private KeyCode interactionKey = KeyCode.E;
        [SerializeField] private InteractionArea interactionArea = null;

        private IInteractable currentInteractable = null;

        private void Awake()
        {
            interactionArea = interactionArea != null ? interactionArea : GetComponent<InteractionArea>();
            interactionArea.OnTriggerEnter += RecieveInteractable;
            interactionArea.OnTriggerExit += (obj) => RemoveInteractable();
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
            }
        }

        private void RemoveInteractable()
        {
            if (currentInteractable != null)
            {
                currentInteractable.TogglePopup(false);
                currentInteractable = null;
            }
        }
    }
}