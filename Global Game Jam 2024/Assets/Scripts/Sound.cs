using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [HideInInspector] public AudioSource source;
    public string name;
    public AudioClip clip;
    // [Range(0, 1)] public float volume;
    public bool playOnAwake;
}
