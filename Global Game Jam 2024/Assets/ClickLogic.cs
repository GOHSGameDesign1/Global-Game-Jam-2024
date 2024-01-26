using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ClickLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked");
            Click();
        }
    }

    void Click()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (hit)
        {
            Debug.Log(hit.transform.name);
            Debug.Log("hit");
        }
    }
}
