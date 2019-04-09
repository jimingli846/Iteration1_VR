using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonController : MonoBehaviour
{
    public bool isClicked;
    public Level level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isClicked)
        {
            level.levelIsFinished = true;
        }
    }
}
