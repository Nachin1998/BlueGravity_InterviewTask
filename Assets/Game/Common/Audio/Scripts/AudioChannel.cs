using System;
using UnityEngine;

namespace BlueGravity.Common.Audio
{
    [CreateAssetMenu(fileName = "channel_audio_", menuName = "ScriptableObjects/Common/Audio/Channel")]
    public class AudioChannel : ScriptableObject
    {
        public Action<AudioSO> OnTriggerSFX = null;
        public Action<AudioSO> OnTriggerMusic = null;
    }
}