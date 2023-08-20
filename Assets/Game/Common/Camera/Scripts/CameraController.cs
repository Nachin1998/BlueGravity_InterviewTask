using UnityEngine;

namespace BlueGravity.Common.Controller
{
    public class CameraController : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private Camera mainCamera = null;
        [SerializeField] private Vector3 offsetFromtarget = Vector3.zero;

        private Transform target = null;

        private void Update()
        {
            if (target == null)
            {
                return;
            }

            mainCamera.transform.position = target.position - offsetFromtarget;
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}