using UnityEngine;

namespace BlueGravity.Common.Controller
{
    public abstract class SceneController : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private AudioController audioController = null;

        private void Awake()
        {
            audioController.Init();
            Init();
        }

        protected abstract void Init();
        protected abstract void OnEnable();
        protected abstract void OnDisable();
    }
}