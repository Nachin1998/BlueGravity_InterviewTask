using UnityEngine;

public class SpriteCharacterView : CharacterView<SpriteRenderer>
{
    public override Sprite HeadAccessory { get => headAccessoriesRenderer.sprite; }
    public override Sprite HeadHair { get => headHairRenderer.sprite; }
    public override Sprite Body { get => bodyRenderer.sprite; }

    public override void CopyBody(CharacterView<SpriteRenderer> character)
    {
        headAccessoriesRenderer.sprite = character.HeadAccessory;
        headHairRenderer.sprite = character.HeadHair;
        bodyRenderer.sprite = character.Body;
    }
}
