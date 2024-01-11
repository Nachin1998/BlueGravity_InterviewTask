using UnityEngine;

using BlueGravity.Common.Characters;

namespace BlueGravity.Common.Player
{
    public class PlayerView : SpriteCharacterView
    {
        [Header("Player Configuration")]
        [SerializeField] private Rigidbody2D rigidbody2d = null;
        [SerializeField] private float movementSpeed = 5.0f;

        private Vector2 movement = Vector2.zero;

        private void Update()
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            SetAnimationDirection(movement);
            SetAnimationSpeed(movement.magnitude);
        }

        private void FixedUpdate()
        {
            rigidbody2d.MovePosition(rigidbody2d.position + movementSpeed * Time.fixedDeltaTime * movement);
        }
    }
}