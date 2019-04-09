using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoorProcess()
    {
        if (StepManager.Instance.currentStepId == "4.1")
            StepManager.Instance.Process("4.1");

        else if (StepManager.Instance.currentStepId == "7.4")
            StepManager.Instance.Process("7.4");

        else if (StepManager.Instance.currentStepId == "7.6")
            StepManager.Instance.Process("7.6");

        else if (StepManager.Instance.currentStepId == "11.1")
            StepManager.Instance.Process("11.1");
    }
}
