using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ByteManager : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    public AudioSource source; 

    public SoundByte line;

    public SoundByte[] lines;

    public int index;


    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        Play();
    }

    void Play()
    {
        if (index >= lines.Length) return;
        SoundByte currentLine = lines[index];
        source.clip = currentLine.clip;
        tmp.text = currentLine.text;
        ToggleText();
        Invoke("ToggleText", source.clip.length); // Disables subtitles once audio clip ends
        if (currentLine.playNext)
        {
            Invoke("Play", source.clip.length);
        }
        source.Play();
        index++;
    }

    void ToggleText()
    {
        tmp.gameObject.SetActive(!tmp.gameObject.activeSelf);
    }
}
