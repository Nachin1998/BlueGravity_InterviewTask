using UnityEngine;

namespace BlueGravity.Common.Audio
{
    public class AudioController : MonoBehaviour
    {
        [Header("Main Configuration")]
        [SerializeField] private AudioChannel channel = null;
        [SerializeField] private AudioSource musicSource = null;
        [SerializeField] private AudioSource sfxSource = null;

        public void Init()
        {
            channel.TriggerMusic = TriggerMusic;
            channel.TriggerSFX = TriggerSFX;
        }

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
    }
}