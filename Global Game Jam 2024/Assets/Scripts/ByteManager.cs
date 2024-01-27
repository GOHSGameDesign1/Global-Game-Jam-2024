using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ByteManager : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    public SoundByte line; 

    // Start is called before the first frame update
    void Start()
    {
        tmp.text = line.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
