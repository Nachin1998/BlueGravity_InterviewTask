using UnityEngine;

namespace BlueGravity.Common.Characters
{
    public class SpriteCharacterView : CharacterView<SpriteRenderer>
    {
        public override Sprite HeadAccessory { get => headAccessoriesRenderer.sprite; protected set => headAccessoriesRenderer.sprite = value; }
        public override Sprite HeadHair { get => headHairRenderer.sprite; protected set => headHairRenderer.sprite = value; }
        public override Sprite Body { get => bodyRenderer.sprite; protected set => bodyRenderer.sprite = value; }
    }
}