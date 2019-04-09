using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PPESafety : MonoBehaviour
{

    bool leftGloveOn, rightGloveOn;
    bool respiratorOn;
    bool shoesOn = true;
    

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(StepManager.Instance.currentStepId == "1.1" && leftGloveOn && rightGloveOn)     //Gloves
        {
            StepManager.Instance.Process("1.1");
            leftGloveOn = false;
            rightGloveOn = false;
        }
        else if (StepManager.Instance.currentStepId == "1.2" && respiratorOn)
        {
            StepManager.Instance.Process("1.2");
            respiratorOn = false;
        }
        else if (StepManager.Instance.currentStepId == "1.3" && shoesOn)
        {
            StepManager.Instance.Process("1.3");
            shoesOn = false;
        }

        //Debug.Log("Left Glove On: " + leftGloveOn + "; Right Glove On: " + rightGloveOn + "; Respirator On: " + respiratorOn);
    }

    public void LeftGloveOn()
    {
        leftGloveOn = true;
    }

    public void RightGloveOn()
    {
        rightGloveOn = true;
    }
    
    public void RespiratorOn()
    {
        respiratorOn = true;
    }

}
