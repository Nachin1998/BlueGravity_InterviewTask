using UnityEngine;
using UnityEngine.UI;

public class UICharacterView : CharacterView<Image>
{
    public override Sprite HeadAccessory 
    { 
        get => headAccessoriesRenderer.sprite; 
        protected set
        {
            headAccessoriesRenderer.enabled = value != null;
            headAccessoriesRenderer.sprite = value;
        }
    }

    public override Sprite HeadHair { get => headHairRenderer.sprite;
        protected set
        {
            headHairRenderer.enabled = value != null;
            headHairRenderer.sprite = value;
        }
    }

    public override Sprite Body { get => bodyRenderer.sprite;
        protected set
        {
            bodyRenderer.enabled = value != null;
            bodyRenderer.sprite = value;
        }
    }
}
