using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonClick : MonoBehaviour, IClickable
{
    float smoothTime = 0.3f;
    Vector2 yVelocity = Vector2.zero;

    private void Update()
    {
        if(ByteManager.Instance.index >= 2)
         {
               transform.localScale = new Vector2(1 ,1);
             //transform.localScale = Vector2.SmoothDamp(transform.localScale, new Vector2(1, 1), ref yVelocity, smoothTime);
         }
    }

    public void OnClick()
    {
        if (ByteManager.Instance.isPlaying) return;
        AudioManager.instance.PlaySound("GunShot");
        if (AudioManager.instance.GetSound("GunShot") != null) ByteManager.Instance.Invoke("Play", AudioManager.instance.GetSound("GunShot").clip.length);
        Debug.Log("Clicked Triangle");
        Destroy(gameObject);
    }
}
