using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Interactor : MonoBehaviour
{
    [SerializeField] private KeyCode interactionKey = KeyCode.None;

    private IInteractable currentInteractable = null;

    private void Update()
    {
        if (currentInteractable == null)
        {
            return;
        }    

        if (Input.GetKeyDown(interactionKey)) 
        {
            currentInteractable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IInteractable interactable))
        {
            currentInteractable = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IInteractable interactable))
        {
            if (currentInteractable == interactable)
            {
                currentInteractable = null;
            }
        }
    }
}
