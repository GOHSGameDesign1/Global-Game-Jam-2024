using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ByteManager : MonoBehaviour
{
    public static ByteManager Instance;

    public TextMeshProUGUI tmp;

    public AudioSource source;

    public SoundByte line;

    public SoundByte[] lines;

    public int index;

    public bool isPlaying { get; private set; }

    public delegate void ManTrigger();
    public static ManTrigger manTrigger;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Debug.LogWarning("ByteManagers found!");
            Destroy(gameObject);
        }
    }

    public static ByteManager GetInstance()
    {
        return Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        Play();
    }

    public void Play()
    {
        if (index >= lines.Length) return;
        StartCoroutine("PlayLine");
    }

    IEnumerator PlayLine()
    {
        SoundByte currentLine = lines[index];
        source.clip = currentLine?.clip;
        tmp.text = currentLine.text;

        yield return new WaitForSeconds(currentLine.startDelay);
        tmp.gameObject.SetActive(true);
        isPlaying = true;

        if (source.clip != null)
        {
            float time = 0;
            source.Play();
            while (time < source.clip.length)
            {
                time += Time.deltaTime;
                yield return null;
            }
        }

        tmp.gameObject.SetActive(false);

        if (currentLine.triggerPersonEvent)
        {
            manTrigger?.Invoke();
        }

        if (currentLine.triggerSceneSwitch)
        {
            GameManager.Instance.SwitchScene(2f);
            yield break;
        }

        index++;

        if (currentLine.playNext)
        {
            Play();
        }
        else
        {
            isPlaying = false;
        }

    }
}
