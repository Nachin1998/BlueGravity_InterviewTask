using System.Collections.Generic;

using UnityEngine;

using BlueGravity.Common.Items.Body;

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
        [SerializeField] protected Animator[] bodyPartAnimators = null;

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

        public void SetParts(List<BodyPartItemSO> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                SetPart(items[i]);
            }
        }

        public void SetPart(BodyPartItemSO item)
        {
            if (bodyPartAnimators != null && bodyPartAnimators.Length > 0)
            {
                bodyPartAnimators[(int)item.Part].runtimeAnimatorController = item.AnimatorController;
            }

            switch (item.Part)
            {
                case BODY_PART.ACCESSORY:
                    HeadAccessory = item.Icon;
                    break;

                case BODY_PART.HAIR:
                    HeadHair = item.Icon;
                    break;

                case BODY_PART.COSTUME:
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

        public void RemovePart(BODY_PART part)
        {
            if (bodyPartAnimators != null && bodyPartAnimators.Length > 0)
            {
                bodyPartAnimators[(int)part].runtimeAnimatorController = null;
            }

            switch (part)
            {
                case BODY_PART.ACCESSORY:
                    HeadAccessory = null;
                    break;
                case BODY_PART.HAIR:
                    HeadHair = null;
                    break;
                case BODY_PART.COSTUME:
                    Body = null;
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

            for (int i = 0; i < bodyPartAnimators.Length; i++)
            {
                if (bodyPartAnimators[i].runtimeAnimatorController != null)
                {
                    bodyPartAnimators[i].SetFloat(axis, value);
                }
            }
        }
    }
}