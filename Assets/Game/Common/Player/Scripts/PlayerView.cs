using UnityEngine;

using BlueGravity.Common.Characters;
using BlueGravity.Common.Items.BodyParts;

namespace BlueGravity.Common.Player
{
    public class PlayerView : SpriteCharacterView
    {
        [Header("Player Configuration")]
        [SerializeField] private Rigidbody2D rigidbody2d = null;
        [SerializeField] private float movementSpeed = 5.0f;

        private Vector2 movement = Vector2.zero;

        private bool inputEnabled = true;

        private void Update()
        {
            if (!inputEnabled)
            {
                return;
            }

            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            SetAnimationDirection(movement);
            SetAnimationSpeed(movement.magnitude);
        }

        private void FixedUpdate()
        {
            if (!inputEnabled)
            {
                return;
            }

            rigidbody2d.MovePosition(rigidbody2d.position + movementSpeed * Time.fixedDeltaTime * movement);
        }

        public void ToggleInteraction(bool status)
        {
            inputEnabled = status;

            if (!inputEnabled)
            {
                SetAnimationDirection(Vector2.zero);
                SetAnimationSpeed(0.0f);
            }
        }
    }
}