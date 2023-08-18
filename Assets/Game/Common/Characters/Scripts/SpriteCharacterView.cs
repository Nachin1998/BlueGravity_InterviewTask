using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCharacterView : CharacterView<SpriteRenderer>
{
    public override Sprite HeadAccessory { get => headAccessoriesRenderer.sprite; }
    public override Sprite HeadHair { get => headHairRenderer.sprite; }
    public override Sprite Body { get => bodyRenderer.sprite; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
