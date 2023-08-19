using System;

using UnityEngine;

public class ShopKeeperView : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionArea interactionArea = null;

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
                    isInteractable = true;
                    onCustomerInRange?.Invoke();
                }
            },
            onTriggerExit: (obj) =>
            {
                if (obj.TryGetComponent(out IShopCustomer customer))
                {
                    isInteractable = false;
                    onCustomerLeave?.Invoke();
                }
            });
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