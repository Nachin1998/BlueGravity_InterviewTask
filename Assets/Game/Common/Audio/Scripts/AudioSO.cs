using UnityEngine;

namespace BlueGravity.Common.Audio
{
    [CreateAssetMenu(fileName = "audio_", menuName = "ScriptableObjects/Common/Audio/SFX Audio")]
    public class AudioSO : ScriptableObject
    {
        [Header("Main Configuration")]
        [SerializeField] private AudioClip clip = null;
        [SerializeField][Range(0, 1)] private float volume = 1.0f;
        [SerializeField] private bool loop = false;

        public AudioClip Clip { get => clip; }
        public float Volume { get => volume; }
        public bool Loop { get => loop; }
    }
}