using BlueGravity.Common.Skins;
using UnityEngine;

namespace BlueGravity.Common.Characters
{
    public abstract class CharacterView<TRenderer> : MonoBehaviour where TRenderer : Component
    {
        [Header("Main Configuration")]
        [SerializeField] protected TRenderer accessoryRenderer = null;
        [SerializeField] protected TRenderer hairRenderer = null;
        [SerializeField] protected TRenderer costumeRenderer = null;
        
        [Header("Animators Configuration")]
        [SerializeField] private Animator[] bodyAnimators = null;
        
        public abstract Sprite HeadAccessorySprite { get; protected set; }
        public abstract Sprite HeadHairSprite { get; protected set; }
        public abstract Sprite BodyCostumeSprite { get; protected set; }

        private readonly int speedHash = Animator.StringToHash("speed");
        private readonly int horizontalHash = Animator.StringToHash("horizontal");
        private readonly int verticalHash = Animator.StringToHash("vertical");

        public void Copy(CharacterView<TRenderer> character)
        {
            HeadAccessorySprite = character.HeadAccessorySprite;
            HeadHairSprite = character.HeadHairSprite;
            BodyCostumeSprite = character.BodyCostumeSprite;
        }

        protected void SetAnimationSpeed(float speed)
        {
            for (int i = 0; i < bodyAnimators.Length; i++)
            {
                bodyAnimators[i].SetFloat(speedHash, speed);
            }
        }

        protected void SetAnimationDirection(Vector2 direction)
        {
            for (int i = 0; i < bodyAnimators.Length; i++)
            {
                bodyAnimators[i].SetFloat(horizontalHash, direction.x);
                bodyAnimators[i].SetFloat(verticalHash, direction.y);
            }
        }
    }
}