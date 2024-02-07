using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeClick : MonoBehaviour, IClickable
{
    public ParticleSystem explodeParticles1;
    public ParticleSystem explodeParticles2;

    public void OnClick()
    {
        if (ByteManager.Instance.isPlaying) return;
        if (AudioManager.instance.GetSound("Explode") != null) ByteManager.Instance.Invoke("Play", AudioManager.instance.GetSound("Explode").clip.length);
        Explode();
    }

    private void Explode()
    {
        Instantiate(explodeParticles1, transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(explodeParticles2, transform.position, Quaternion.Euler(0, 0, 0));

        GetComponent<SpriteRenderer>().color = Color.clear;
    }
}
