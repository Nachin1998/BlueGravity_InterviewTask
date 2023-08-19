using UnityEngine;
using UnityEngine.UI;

public class UICharacterView : CharacterView<Image>
{
    public override Sprite HeadAccessory { get => headAccessoriesRenderer.sprite; }
    public override Sprite HeadHair { get => headHairRenderer.sprite; }
    public override Sprite Body { get => bodyRenderer.sprite; }

    public override void CopyBody(CharacterView<Image> character)
    {
        headAccessoriesRenderer.enabled = character.HeadAccessory != null;
        headHairRenderer.enabled = character.HeadHair != null;
        bodyRenderer.enabled = character.Body != null;

        headAccessoriesRenderer.sprite = character.HeadAccessory;
        headHairRenderer.sprite = character.HeadHair;
        bodyRenderer.sprite = character.Body;
    }
}
