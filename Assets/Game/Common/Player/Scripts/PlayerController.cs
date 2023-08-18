using UnityEngine;

namespace BlueGravity.Common.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 1.0f;
        [SerializeField] private Rigidbody2D rb2d = null;

        private Vector2 movement = Vector2.zero;

        private void Update()
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            rb2d.MovePosition(rb2d.position + movement * movementSpeed * Time.fixedDeltaTime);
        }
    }
}