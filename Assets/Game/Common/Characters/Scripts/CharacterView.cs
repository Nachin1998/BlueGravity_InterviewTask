using UnityEngine;

using BlueGravity.Common.Items.BodyParts;
using BlueGravity.Common.Skins;

namespace BlueGravity.Common.Characters
{
    public abstract class CharacterView<TRenderer> : MonoBehaviour where TRenderer : Component
    {
        [Header("Main Configuration")]
        [SerializeField] protected TRenderer accessoryRenderer = null;
        [SerializeField] protected TRenderer hairRenderer = null;
        [SerializeField] protected TRenderer costumeRenderer = null;
        
        [Header("Animators Configuration")]
        [SerializeField] private Animator bodyAnimator = null;
        [SerializeField] private Animator[] bodyAnimators = null;

        [Header("Skin Configuration")]
        [SerializeField] private SkinSO startingSkin = null;
        
        public abstract Sprite HeadAccessorySprite { get; protected set; }
        public abstract Sprite HeadHairSprite { get; protected set; }
        public abstract Sprite BodyCostumeSprite { get; protected set; }

        private readonly int speedHash = Animator.StringToHash("speed");
        private readonly int horizontalHash = Animator.StringToHash("horizontal");
        private readonly int verticalHash = Animator.StringToHash("vertical");

        private void Awake()
        {
            if (startingSkin != null)
            {
                SetBodyPart(startingSkin.AccessoryItem);
                SetBodyPart(startingSkin.HairItem);
                SetBodyPart(startingSkin.CostumeItem);
            }
        }

        private void SetBodyPart(BodyPartItemSO item)
        {
            switch (item.Part)
            {
                case BODY_PART.ACCESSORY:
                    HeadAccessorySprite = item.Icon;
                    break;

                case BODY_PART.HAIR:
                    HeadHairSprite = item.Icon;
                    break;

                case BODY_PART.COSTUME:
                    BodyCostumeSprite = item.Icon;
                    break;
            }

            int index = (int)item.Part;
            bodyAnimators[index].runtimeAnimatorController = item.AnimatorController;
        }

        protected void SetAnimationSpeed(float speed)
        {
            bodyAnimator.SetFloat(speedHash, speed);
            
            for (int i = 0; i < bodyAnimators.Length; i++)
            {
                if (bodyAnimators[i].runtimeAnimatorController != null)
                {
                    bodyAnimators[i].SetFloat(speedHash, speed);
                }
            }
        }

        protected void SetAnimationDirection(Vector2 direction)
        {
            bodyAnimator.SetFloat(horizontalHash, direction.x);
            bodyAnimator.SetFloat(verticalHash, direction.y);

            for (int i = 0; i < bodyAnimators.Length; i++)
            {
                if (bodyAnimators[i].runtimeAnimatorController != null)
                {
                    bodyAnimators[i].SetFloat(horizontalHash, direction.x);
                    bodyAnimators[i].SetFloat(verticalHash, direction.y);
                }
            }
        }
    }
}