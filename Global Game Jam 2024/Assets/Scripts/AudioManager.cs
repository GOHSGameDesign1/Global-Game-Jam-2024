using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Debug.LogWarning("Two Instances Detected!");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string soundName)
    {
        Sound currentSound = Array.Find(sounds, s => s.name == soundName);
        currentSound?.source.Play();
    }

    public Sound GetSound(string soundName)
    {
        return Array.Find(sounds, s => s.name == soundName);
    }
}
