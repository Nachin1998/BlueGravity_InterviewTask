using System;
using UnityEngine;

public class FashionDesignerView : MonoBehaviour, IInteractable
{
    [Header("Main Configuration")]
    [SerializeField] private InteractionArea interactionArea = null;
    [SerializeField] private GameObject speechBubble = null;

    [Header("Audio Configuration")]
    [SerializeField] private AudioChannel audioChannel = null;
    [SerializeField] private AudioSO popupSFX = null;

    private bool isInteractable = true;
    private Action OnInteracted = null;

    public void Init(Action onInteracted, Action<SpriteCharacterView> onCustomerInRange, Action onCustomerLeave)
    {
        OnInteracted = onInteracted;
        interactionArea.Init(
            onTriggerEnter: (obj) =>
            {
                if (obj.TryGetComponent(out SpriteCharacterView character))
                {
                    ProcessInteraction(true);
                    onCustomerInRange?.Invoke(character);
                }
            },
            onTriggerExit: (obj) =>
            {
                if (obj.TryGetComponent(out SpriteCharacterView character))
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
