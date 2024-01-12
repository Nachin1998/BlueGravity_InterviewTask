using UnityEngine;

using System.Collections.Generic;

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
        [SerializeField] protected SkinSO startingSkin = null;
        [SerializeField] protected SkinSO fallbackSkin = null;

        private BodyPartItemSO accessoryItem = null;
        private BodyPartItemSO hairItem = null;
        private BodyPartItemSO costumeItem = null;

        public abstract Sprite HeadAccessorySprite { get; protected set; }
        public abstract Sprite HeadHairSprite { get; protected set; }
        public abstract Sprite BodyCostumeSprite { get; protected set; }

        public List<BodyPartItemSO> BodyParts { get => new List<BodyPartItemSO>() { accessoryItem, hairItem, costumeItem }; }

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

        public void SetBodyPart(BodyPartItemSO item)
        {
            if (item == null)
            {
                return;
            }

            if (bodyAnimators.Length > 0)
            {
                int index = (int)item.Part;
                bodyAnimators[index].runtimeAnimatorController = item.AnimatorController;
            }

            switch (item.Part)
            {
                case BODY_PART.ACCESSORY:
                    HeadAccessorySprite = item.Icon;
                    accessoryItem = item;
                    break;

                case BODY_PART.HAIR:
                    HeadHairSprite = item.Icon;
                    hairItem = item;
                    break;

                case BODY_PART.COSTUME:
                    BodyCostumeSprite = item.Icon;
                    costumeItem = item;
                    break;
            }
        }

        public void Copy<T>(CharacterView<T> character) where T : Component
        {
            SetBodyPart(character.accessoryItem);
            SetBodyPart(character.hairItem);
            SetBodyPart(character.costumeItem);
        }

        public void RemovePart(BodyPartItemSO item)
        {
            int index = (int)item.Part;

            if (bodyAnimators[index].runtimeAnimatorController == item.AnimatorController)
            {
                bodyAnimators[index].runtimeAnimatorController = null;

                switch (item.Part)
                {
                    case BODY_PART.ACCESSORY:
                        HeadAccessorySprite = null;
                        accessoryItem = fallbackSkin.AccessoryItem;
                        break;

                    case BODY_PART.HAIR:
                        HeadHairSprite = null;
                        hairItem = fallbackSkin.HairItem;
                        break;

                    case BODY_PART.COSTUME:
                        BodyCostumeSprite = null;
                        costumeItem = fallbackSkin.CostumeItem;
                        break;
                }
            }
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