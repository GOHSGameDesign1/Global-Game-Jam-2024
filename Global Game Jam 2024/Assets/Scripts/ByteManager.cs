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

    public ByteManager GetInstance()
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
        if (index >= lines.Length)
        {
            Invoke("ToggleIsPlaying", source.clip.length);
            return;
        }

        isPlaying = true;
        SoundByte currentLine = lines[index];
        source.clip = currentLine.clip;
        tmp.text = currentLine.text;
        ToggleText();
        Invoke("ToggleText", source.clip.length); // Disables subtitles once audio clip ends
        if (currentLine.playNext)
        {
            Invoke("Play", source.clip.length);
        } else
        {
            Invoke("ToggleIsPlaying", source.clip.length);
        }
        source.Play();
        index++;
    }

    void ToggleText()
    {
        tmp.gameObject.SetActive(!tmp.gameObject.activeSelf);
    }

    void ToggleIsPlaying()
    {
        isPlaying = !isPlaying;
    }
}
