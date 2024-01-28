using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleClick : MonoBehaviour, IClickable
{
    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        if (ByteManager.Instance.isPlaying) return;
        source.Play();
        ByteManager.Instance.Invoke("Play", source.clip.length);
        Debug.Log("Clicked Triangle");
    }
}
