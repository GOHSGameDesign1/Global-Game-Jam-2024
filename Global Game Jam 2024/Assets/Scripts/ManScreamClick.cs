using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManScreamClick : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        if (ByteManager.Instance.isPlaying) return;
        AudioManager.instance.PlaySound("ManScream");
    }
}
