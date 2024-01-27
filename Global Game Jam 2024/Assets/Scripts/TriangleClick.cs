using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleClick : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        Debug.Log("Clicked Triangle");
    }
}
