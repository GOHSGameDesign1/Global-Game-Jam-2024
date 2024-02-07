using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance != null) 
        {
            Debug.LogWarning("Multiple instances detected! Destroying this gameobject");
            Destroy(gameObject);
            return;
        }   

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void SwitchScene(float timeToSwitch)
    {
        Invoke("Switch", timeToSwitch);
    }

    void Switch()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(sceneIndex >= SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.LogWarning("Tried to switch to a scene that doesn't exist!");
            return;
        }

        if(SceneManager.GetActiveScene().buildIndex + 1 == 5)
        {
            AudioManager.instance.StopAllSounds();
            AudioManager.instance.PlaySound("Ocean");
        }

        if (SceneManager.GetActiveScene().buildIndex + 1 == 6)
        {
            AudioManager.instance.StopAllSounds();
            AudioManager.instance.PlaySound("Forest");
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
