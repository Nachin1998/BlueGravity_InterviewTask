using UnityEngine;

namespace BlueGravity.Common.Controller
{
    public class CameraController : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private Camera mainCamera = null;
        [SerializeField] private Vector3 offsetFromtarget = Vector3.zero;
        [SerializeField] private float size = 10.0f;

        private Transform target = null;

        private void Update()
        {
            if (target == null)
            {
                return;
            }

            mainCamera.transform.position = target.position - offsetFromtarget;
            mainCamera.orthographicSize = size;
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}