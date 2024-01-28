using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SoundByte : ScriptableObject
{
    public AudioClip clip;
    [TextArea(15, 20)] public string text;
    [Range(0f, 3f)] public float startDelay;
    [Range(0f, 3f)] public float endDelay;
}
