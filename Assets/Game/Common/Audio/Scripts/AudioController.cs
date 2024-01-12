using UnityEngine;

namespace BlueGravity.Common.Audio
{
    public class AudioController : MonoBehaviour
    {
        #region EXPOSED_FIELDS
        [Header("Main Configuration")]
        [SerializeField] private AudioChannel channel = null;
        [SerializeField] private AudioSource musicSource = null;
        [SerializeField] private AudioSource sfxSource = null;
        #endregion

        #region PUBLIC_METHODS
        public void Init()
        {
            channel.TriggerMusic = TriggerMusic;
            channel.TriggerSFX = TriggerSFX;
        }
        #endregion

        #region PRIVATE_METHODS
        private void TriggerMusic(AudioSO so)
        {
            musicSource.volume = so.Volume;
            musicSource.loop = so.Loop;
            musicSource.clip = so.Clip;
            musicSource.Play();
        }

        private void TriggerSFX(AudioSO so)
        {
            sfxSource.volume = so.Volume;
            sfxSource.loop = so.Loop;
            sfxSource.PlayOneShot(so.Clip);
        }
        #endregion
    }
}