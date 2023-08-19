using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "audio_", menuName = "ScriptableObjects/Common/Audio/SFX Audio")]
public class AudioSO : ScriptableObject
{
    [SerializeField] private AudioClip clip = null;
    [SerializeField][Range(0, 1)] private float volume = 1.0f;

    public AudioClip Clip { get => clip; }
    public float Volume { get => volume; }
}