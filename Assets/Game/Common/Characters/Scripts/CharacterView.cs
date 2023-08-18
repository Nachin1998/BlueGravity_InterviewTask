using UnityEngine;

public abstract class CharacterView<T> : MonoBehaviour where T : Component
{
    [Header("Main Configuration")]
    [SerializeField] protected T headAccessoriesRenderer = null;
    [SerializeField] protected T headHairRenderer = null;
    [SerializeField] protected T bodyRenderer = null;

    public abstract Sprite HeadAccessory { get; }
    public abstract Sprite HeadHair { get; }
    public abstract Sprite Body { get; }
}
