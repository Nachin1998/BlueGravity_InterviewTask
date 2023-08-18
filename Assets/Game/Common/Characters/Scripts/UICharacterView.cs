using UnityEngine;
using UnityEngine.UI;

public class UICharacterView : CharacterView<Image>
{
    public override Sprite HeadAccessory { get => headAccessoriesRenderer.sprite; }
    public override Sprite HeadHair { get => headHairRenderer.sprite; }
    public override Sprite Body { get => bodyRenderer.sprite; }
}
