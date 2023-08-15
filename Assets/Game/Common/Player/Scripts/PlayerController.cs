using UnityEngine;

namespace BlueGravity.Game.Hub.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 1.0f;
        [SerializeField] private Vector3 cameraPositionOffset = Vector3.zero;
        [SerializeField] private Rigidbody2D rb2d = null;

        private Camera mainCamera = null;
        private Vector2 movement = Vector2.zero;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            mainCamera.transform.position = transform.position - cameraPositionOffset;

            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            rb2d.MovePosition(rb2d.position + movement * movementSpeed * Time.fixedDeltaTime);
        }
    }
}