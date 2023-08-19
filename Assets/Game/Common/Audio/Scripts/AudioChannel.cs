using System;
using UnityEngine;

[CreateAssetMenu(fileName = "channel_audio_", menuName = "ScriptableObjects/Common/Audio/Channel")]
public class AudioChannel : ScriptableObject
{
    public Action<AudioSO> OnTriggerAudio = null;
}
