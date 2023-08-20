using UnityEngine;

namespace BlueGravity.Common.Characters
{
    public abstract class CharacterView<TRenderer> : MonoBehaviour where TRenderer : Component
    {
        [Header("Main Configuration")]
        [SerializeField] protected TRenderer headAccessoriesRenderer = null;
        [SerializeField] protected TRenderer headHairRenderer = null;
        [SerializeField] protected TRenderer bodyRenderer = null;

        [Header("Animators Configuration")]
        [SerializeField] protected Animator mainBodyAnimator = null;
        [SerializeField] protected Animator headAccessoriesAnimator = null;
        [SerializeField] protected Animator headHairAnimator = null;
        [SerializeField] protected Animator costumeAnimator = null;

        public int Parts { get => 3; }
        public abstract Sprite HeadAccessory { get; protected set; }
        public abstract Sprite HeadHair { get; protected set; }
        public abstract Sprite Body { get; protected set; }

        public Sprite this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return HeadAccessory;
                    case 1:
                        return HeadHair;
                    case 2:
                        return Body;
                    default:
                        return null;
                }
            }

            set
            {
                switch (index)
                {
                    case 0:
                        HeadAccessory = value;
                        break;
                    case 1:
                        HeadHair = value;
                        break;
                    case 2:
                        Body = value;
                        break;
                }
            }
        }

        public void CopyBody<T>(CharacterView<T> character) where T : Component
        {
            HeadAccessory = character.HeadAccessory;
            HeadHair = character.HeadHair;
            Body = character.Body;
        }

        public void SetItem(BodyPartItemSO item)
        {
            switch (item.Part)
            {
                case BODY_PART.ACCESSORY:
                    headAccessoriesAnimator.runtimeAnimatorController = item.AnimatorController;
                    HeadAccessory = item.Icon;
                    break;

                case BODY_PART.HAIR:
                    headHairAnimator.runtimeAnimatorController = item.AnimatorController;
                    HeadHair = item.Icon;
                    break;

                case BODY_PART.COSTUME:
                    costumeAnimator.runtimeAnimatorController = item.AnimatorController;
                    Body = item.Icon;
                    break;

                case BODY_PART.INVALID:
                    Debug.LogError("Item " + item.Id + " not configured correctly");
                    break;

                default:
                    Debug.Log(item.Part);
                    break;
            }
        }

        public void SetAnimationSpeed(float speed)
        {
            SetAnimationAxis("speed", speed);
        }

        public void SetAnimationAxis(string axis, float value)
        {
            mainBodyAnimator.SetFloat(axis, value);
            headAccessoriesAnimator.SetFloat(axis, value);
            headHairAnimator.SetFloat(axis, value);
            costumeAnimator.SetFloat(axis, value);
        }
    }
}