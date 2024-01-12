using UnityEngine;

using BlueGravity.Common.Audio;

namespace BlueGravity.Common.Controller
{
    public abstract class SceneController : MonoBehaviour
    {
        #region EXPOSED_FIELDS
        [Header("Main Configuration")]
        [SerializeField] private AudioController audioController = null;
        [SerializeField] private AudioChannel audioChannel = null;
        [SerializeField] private AudioSO music = null;
        #endregion

        #region UNITY_CALLS
        private void Awake()
        {
            audioController.Init();
            audioChannel.TriggerMusic(music);

            Init();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }
        }
        #endregion

        #region PROTECTED_METHODS
        protected abstract void Init();
        #endregion
    }
}