using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step4EOSLayout : MonoBehaviour
{
    bool recoaterOn;
    bool buildPlatformOn;
    bool ductOn;
    bool dispenserOn;
    bool rocketOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StepManager.Instance.currentStepId == "4.3" && recoaterOn)     
        {
            StepManager.Instance.Process("4.3");
            recoaterOn = false;
        }
        else if (StepManager.Instance.currentStepId == "4.4" && buildPlatformOn)
        {
            StepManager.Instance.Process("4.4");
            buildPlatformOn = false;
        }
        else if (StepManager.Instance.currentStepId == "4.5" && ductOn)
        {
            StepManager.Instance.Process("4.5");
            ductOn = false;
        }
        else if (StepManager.Instance.currentStepId == "4.6" && dispenserOn)
        {
            StepManager.Instance.Process("4.6");
            dispenserOn = false;
        }
        else if (StepManager.Instance.currentStepId == "4.7" && rocketOn)
        {
            StepManager.Instance.Process("4.7");
            rocketOn = false;
        }
    }

    public void RecoaterOn()
    {
        recoaterOn = true;
    }

    public void BuildPlatformOn()
    {
        buildPlatformOn = true;
    }

    public void DuctOn()
    {
        ductOn = true;
    }

    public void DispenserOn()
    {
        dispenserOn = true;
    }

    public void RocketOn()
    {
        rocketOn = true;
    }
}
