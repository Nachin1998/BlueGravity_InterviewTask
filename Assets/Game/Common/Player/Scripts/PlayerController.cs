using System.Collections.Generic;

using UnityEngine;

using BlueGravity.Common.Characters;
using BlueGravity.Common.Items.Body;

namespace BlueGravity.Common.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private float movementSpeed = 1.0f;
        [SerializeField] private Rigidbody2D rb2d = null;
        [SerializeField] private SpriteCharacterView view = null;

        private Vector2 movement = Vector2.zero;

        private List<BodyPartItemSO> currentParts = null;

        public List<BodyPartItemSO> CurrentParts { get => currentParts; }

        public void Init()
        {
            currentParts = new List<BodyPartItemSO>();
        }

        private void Update()
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            view.SetAnimationAxis("horizontal", movement.x);
            view.SetAnimationAxis("vertical", movement.y);
            view.SetAnimationSpeed(movement.magnitude);
        }

        private void FixedUpdate()
        {
            rb2d.MovePosition(rb2d.position + movementSpeed * Time.fixedDeltaTime * movement);
        }

        public void SetPart(BodyPartItemSO item)
        {
            TryAddPart(item);
        }

        public void RemovePart(BodyPartItemSO item)
        {
            TryRemovePart(item);
        }

        private void TryAddPart(BodyPartItemSO item)
        {
            if (currentParts.Contains(item))
            {
                return;
            }

            for (int i = 0; i < currentParts.Count; i++)
            {
                if (currentParts[i].Part == item.Part)
                {
                    currentParts[i] = item;
                    view.SetPart(item);
                    return;
                }
            }

            currentParts.Add(item);
            view.SetPart(item);
        }

        private void TryRemovePart(BodyPartItemSO item)
        {
            if (currentParts.Contains(item))
            {
                currentParts.Remove(item);
                view.RemovePart(item.Part);
            }
        }
    }
}