using UnityEngine;

namespace BlueGravity.Common.Characters
{
    public abstract class CharacterView<TRenderer> : MonoBehaviour where TRenderer : Component
    {
        [Header("Main Configuration")]
        [SerializeField] protected TRenderer accessoryRenderer = null;
        [SerializeField] protected TRenderer hairRenderer = null;
        [SerializeField] protected TRenderer costumeRenderer = null;
        
        [Header("A Configuration")]
        [SerializeField] private Animator characterAnimator = null;
        [SerializeField] private Animator[] bodyPartAnimators = null;

        public abstract Sprite HeadAccessorySprite { get; protected set; }
        public abstract Sprite HeadHairSprite { get; protected set; }
        public abstract Sprite BodyCostumeSprite { get; protected set; }

        public void Copy(CharacterView<TRenderer> character)
        {
            HeadAccessorySprite = character.HeadAccessorySprite;
            HeadHairSprite = character.HeadHairSprite;
            BodyCostumeSprite = character.BodyCostumeSprite;
        }
    }
}