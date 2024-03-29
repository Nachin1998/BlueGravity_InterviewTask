using UnityEngine;

using BlueGravity.Common.Characters;

namespace BlueGravity.Common.Player
{
    public class PlayerView : SpriteCharacterView
    {
        #region EXPOSED_FIELDS
        [Header("Player Configuration")]
        [SerializeField] private Rigidbody2D rigidbody2d = null;
        [SerializeField] private float movementSpeed = 5.0f;
        #endregion

        #region PRIVATE_FIELDS
        private Vector2 movement = Vector2.zero;

        private bool inputEnabled = true;
        #endregion

        #region UNITY_CALLS
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
        #endregion

        #region PUBLIC_METHODS
        public void ToggleInteraction(bool status)
        {
            inputEnabled = status;

            if (!inputEnabled)
            {
                SetAnimationDirection(Vector2.zero);
                SetAnimationSpeed(0.0f);
            }
        }
        #endregion
    }
}