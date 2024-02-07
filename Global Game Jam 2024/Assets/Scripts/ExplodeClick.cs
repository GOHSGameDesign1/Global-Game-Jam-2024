using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ExplodeClick : MonoBehaviour, IClickable
{
    public ParticleSystem explodeParticles1;
    public ParticleSystem explodeParticles2;

    public bool playNext;
    public bool scream;
    public float lightIntensity;
    public float lightDuration;
    public AnimationCurve lightCurve;
    private Light2D explosionLight;

    private void Awake()
    {
        explosionLight = GetComponent<Light2D>();
    }

    public void OnClick()
    {
        if (ByteManager.Instance.isPlaying) return;
        if (scream) AudioManager.instance.PlaySound("ManScream");
        if ((AudioManager.instance.GetSound("Explode") != null) && (playNext)) ByteManager.Instance.Invoke("Play", AudioManager.instance.GetSound("Explode").clip.length);
        Explode();
    }

    private void Explode()
    {
        Instantiate(explodeParticles1, transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(explodeParticles2, transform.position, Quaternion.Euler(0, 0, 0));

        GetComponent<SpriteRenderer>().color = Color.clear;
        GetComponent<CapsuleCollider2D>().enabled = false;
        StartCoroutine("startLight");
    }

    IEnumerator startLight()
    {
        float time = 0;
        while (time < lightDuration)
        {
            float t = time / lightDuration;
            explosionLight.intensity = lightIntensity * lightCurve.Evaluate(t);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
