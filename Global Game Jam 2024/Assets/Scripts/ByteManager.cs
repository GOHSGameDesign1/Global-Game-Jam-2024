using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ByteManager : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    public AudioSource source; 

    public SoundByte line;


    private void Awake()
    {
        source.clip = line.clip; 
    }
    // Start is called before the first frame update
    void Start()
    {
        tmp.text = line.text;
        Play();
    }

    void Play()
    {
        ToggleText();
        Invoke("ToggleText", source.clip.length); // Disables subtitles once audio clip ends
        source.Play();
    }

    void ToggleText()
    {
        tmp.gameObject.SetActive(!tmp.gameObject.activeSelf);
    }
}
