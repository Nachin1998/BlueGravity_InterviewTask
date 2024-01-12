using BlueGravity.Common.Audio;

using UnityEngine;

namespace BlueGravity.Common.Controller
{
    public abstract class SceneController : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private AudioController audioController = null;
        [SerializeField] private AudioChannel audioChannel = null;
        [SerializeField] private AudioSO music = null;

        private void Awake()
        {
            audioController.Init();
            audioChannel.TriggerMusic(music);

            Init();
        }

        protected abstract void Init();
    }
}