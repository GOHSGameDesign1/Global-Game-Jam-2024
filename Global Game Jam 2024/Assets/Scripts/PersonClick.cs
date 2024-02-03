using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonClick : MonoBehaviour, IClickable
{
    float smoothTime = 1f;
    Vector2 yVelocity = Vector2.zero;

    SpriteRenderer spriteRenderer;
    public Sprite shotSprite;

    bool canBeClicked;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        canBeClicked = false;
    }
    public void OnClick()
    {
        if (ByteManager.Instance.isPlaying) return;
        if (!canBeClicked) return;
        canBeClicked = false;
        AudioManager.instance.PlaySound("GunShot");
        if (AudioManager.instance.GetSound("GunShot") != null) ByteManager.Instance.Invoke("Play", AudioManager.instance.GetSound("GunShot").clip.length);
        Debug.Log("Clicked Triangle");
        spriteRenderer.sprite = shotSprite;
        StartCoroutine(Compress());
    }

    void StretchUp()
    {
        Debug.Log("Stretching");
        StartCoroutine(Stretch());
    }

    IEnumerator Stretch()
    {
        float time = 0;
        float scaleModifier = 0;
        while(time < smoothTime - 0.1f)
        {
            float t = time / smoothTime;
            t = Mathf.Sin(t * Mathf.PI * 0.5f); 

            scaleModifier = Mathf.Lerp(0, 1, t);
            transform.localScale = new Vector2(1, 1 * scaleModifier);

            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = Vector2.one;

        canBeClicked = true;
    }

    IEnumerator Compress()
    {
        float time = 0;
        float scaleModifier = 1;
        yield return new WaitForSeconds(0.5f);
        while (time < 0.2f)
        {
            scaleModifier = Mathf.Lerp(1, 0, time / 0.2f);
            transform.localScale = new Vector2(1, 1 * scaleModifier);

            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = Vector2.right;
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        ByteManager.manTrigger += StretchUp;
    }

    private void OnDisable()
    {
        ByteManager.manTrigger -= StretchUp;
    }
}
