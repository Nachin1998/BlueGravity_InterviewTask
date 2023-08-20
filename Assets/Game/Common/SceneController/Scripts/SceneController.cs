using UnityEngine;

namespace BlueGravity.Common.Controller
{
    public abstract class SceneController : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private AudioController audioController = null;
        [SerializeField] private AudioChannel channel = null;
        [SerializeField] private AudioSO sceneMusic = null;

        private void Awake()
        {
            audioController.Init();
            channel.OnTriggerMusic?.Invoke(sceneMusic);
            Init();
        }

        protected abstract void Init();
        protected abstract void OnEnable();
        protected abstract void OnDisable();
    }
}