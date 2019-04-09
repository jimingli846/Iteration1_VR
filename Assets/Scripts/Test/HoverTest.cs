using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HoverBegin()
    {
        Debug.Log("Begin");
    }

    public void HoverEnds()
    {
        Debug.Log("Ends");
    }

    public void Attach()
    {
        Debug.Log("Attach");
    }

    public void Detach()
    {
        Debug.Log("Detach");
    }
}
