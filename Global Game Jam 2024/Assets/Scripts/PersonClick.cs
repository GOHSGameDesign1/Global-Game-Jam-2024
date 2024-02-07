using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonClick : MonoBehaviour, IClickable
{
    public float smoothTime;

    SpriteRenderer spriteRenderer;
    public Sprite shotSprite;

    bool canBeClicked;

    public float fallRotation;
    [SerializeField] private AnimationCurve stretchCurveY;
    [SerializeField] private AnimationCurve stretchCurveX;
    [SerializeField] private AnimationCurve fallCurve;

    [SerializeField] private ParticleSystem shotVFX;
    [SerializeField] private ParticleSystem deathVFX;

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
        Instantiate(shotVFX, new Vector2(transform.position.x, transform.position.y + 1.2f), Quaternion.Euler(-90, 0 ,0 ));
        if (AudioManager.instance.GetSound("GunShot") != null) ByteManager.Instance.Invoke("Play", AudioManager.instance.GetSound("GunShot").clip.length);
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
        while(time < smoothTime)
        {
            float t = time/smoothTime;
            scaleModifier = stretchCurveY.Evaluate(t);
            transform.localScale = new Vector2(1 * stretchCurveX.Evaluate(t), 1 * scaleModifier);

            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = Vector2.one;

        canBeClicked = true;
    }

    IEnumerator Compress()
    {
        float time = 0;
        while (time < 0.2f)
        {
            float t = time / 0.2f;
            // t = Mathf.Sin(t * Mathf.PI * 0.5f);
            transform.rotation = Quaternion.Euler(0, 0, fallRotation * fallCurve.Evaluate(t));

            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0, 0, fallRotation);

        yield return new WaitForSeconds(1f);
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

    private void OnDestroy()
    {
        Instantiate(deathVFX, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.Euler(-90, 0, 0));
    }
}
