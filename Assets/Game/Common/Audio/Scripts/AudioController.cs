using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioChannel channel = null;
    [SerializeField] private AudioSource source = null;

    public void Init()
    {
        channel.OnTriggerAudio = TriggerAudio;
    }

    private void TriggerAudio(AudioSO so)
    {
        source.volume = so.Volume;
        source.PlayOneShot(so.Clip);
    }
}
