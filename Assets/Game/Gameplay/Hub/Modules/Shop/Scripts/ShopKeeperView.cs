using System;

using UnityEngine;

public class ShopKeeperView : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionArea interactionArea = null;

    private Action OnInteracted = null;

    public void Init(Action onInteracted, Action onCustomerInRange, Action onCustomerLeave)
    {
        OnInteracted = onInteracted;
        interactionArea.Init(
            onTriggerEnter: (obj) =>
            {
                if (obj.TryGetComponent(out IShopCustomer customer))
                {
                    onCustomerInRange?.Invoke();
                }
            },
            onTriggerExit: (obj) =>
            {
                if (obj.TryGetComponent(out IShopCustomer customer))
                {
                    onCustomerLeave?.Invoke();
                }
            });
    }

    public void Interact()
    {
        OnInteracted?.Invoke();
    }
}