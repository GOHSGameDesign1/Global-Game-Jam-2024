using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleClick : MonoBehaviour, IClickable
{

    private void Awake()
    {

    }

    public void OnClick()
    {
        if (ByteManager.Instance.isPlaying) return;
        AudioManager.instance.PlaySound("GunShot");
        if(AudioManager.instance.GetSound("GunShot") != null) ByteManager.Instance.Invoke("Play", AudioManager.instance.GetSound("GunShot").clip.length);
        Debug.Log("Clicked Triangle");
        Destroy(gameObject);
    }
}
