using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTextureTest : MonoBehaviour
{
    public Material green;
    public Material red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGreen()
    {
        this.GetComponent<Renderer>().material = green;
    }
    public void SetRed()
    {
        this.GetComponent<Renderer>().material = red;
    }
}
