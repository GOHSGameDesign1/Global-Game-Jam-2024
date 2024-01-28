using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleClick : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        if (ByteManager.Instance.isPlaying) return;
        ByteManager.Instance.Play();
        Debug.Log("Clicked Triangle");
    }
}
