using UnityEngine;

public abstract class CharacterView<TRenderer> : MonoBehaviour where TRenderer : Component
{
    [Header("Main Configuration")]
    [SerializeField] protected TRenderer headAccessoriesRenderer = null;
    [SerializeField] protected TRenderer headHairRenderer = null;
    [SerializeField] protected TRenderer bodyRenderer = null;

    public abstract Sprite HeadAccessory { get; }
    public abstract Sprite HeadHair { get; }
    public abstract Sprite Body { get; }

    public abstract void CopyBody(CharacterView<TRenderer> character);
}
