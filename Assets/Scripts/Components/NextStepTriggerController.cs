using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStepTriggerController : MonoBehaviour
{
    public Collider[] nextStepTriggers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableNextStepColliders()
    {
        foreach(Collider trigger in nextStepTriggers)
        {
            trigger.enabled = true;
        }
    }
}
