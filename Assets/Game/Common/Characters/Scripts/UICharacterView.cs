using UnityEngine;
using UnityEngine.UI;

namespace BlueGravity.Common.Characters
{
    public class UICharacterView : CharacterView<Image>
    {
        public override Sprite HeadAccessorySprite
        {
            get => accessoryRenderer.sprite;
            protected set
            {
                accessoryRenderer.sprite = value;
                accessoryRenderer.enabled = value != null;
            }
        }
        public override Sprite HeadHairSprite 
        { 
            get => hairRenderer.sprite; 
            protected set 
            {
                hairRenderer.sprite = value; 
                hairRenderer.enabled = value != null; 
            } 
        }
        public override Sprite BodyCostumeSprite
        {
            get => costumeRenderer.sprite;
            protected set
            {
                costumeRenderer.sprite = value;
                costumeRenderer.enabled = value != null;
            }
        }
    }
}