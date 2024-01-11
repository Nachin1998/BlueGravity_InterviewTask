using UnityEngine;

namespace BlueGravity.Common.Controller
{
    public class CameraController : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private Camera mainCamera = null;
        [SerializeField] private Vector3 offsetFromTarget = Vector3.zero;
        [SerializeField] private Transform startingTarget = null;
        [SerializeField] private float zoom = 10.0f;

        private Transform target = null;

        private void Awake()
        {
            target = startingTarget;
        }

        private void Update()
        {
            if (target == null)
            {
                return;
            }

            mainCamera.transform.position = target.position - offsetFromTarget;
            mainCamera.orthographicSize = zoom;
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        public void SetZoom(float zoom)
        {
            this.zoom = zoom;
        }
    }
}