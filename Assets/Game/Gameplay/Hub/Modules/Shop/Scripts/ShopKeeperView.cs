using System;

using UnityEngine;

public class ShopKeeperView : MonoBehaviour, IInteractable
{
    private Action OnInteracted = null;

    public void Init(Action onInteracted)
    {
        OnInteracted = onInteracted;
    }

    public void Interact()
    {
        OnInteracted?.Invoke();
    }
}