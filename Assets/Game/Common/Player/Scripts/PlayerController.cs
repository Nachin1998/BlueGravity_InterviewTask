using UnityEngine;

using BlueGravity.Common.Characters;

namespace BlueGravity.Common.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private float movementSpeed = 1.0f;
        [SerializeField] private Rigidbody2D rb2d = null;
        [SerializeField] private SpriteCharacterView view = null;

        private Vector2 movement = Vector2.zero;

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
            rb2d.MovePosition(rb2d.position + movement * movementSpeed * Time.fixedDeltaTime);
        }
    }
}