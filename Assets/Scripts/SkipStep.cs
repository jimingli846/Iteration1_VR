using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipStep : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject plateHolderPivot;
    void Start()
    {
        plateHolderPivot = GameObject.Find("PlateHolderPivot");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SkipCurrentStep();
        }
    }

    public void SkipCurrentStep()
    {

        if (StepManager.Instance.currentStepId == "6.10")
        {
            plateHolderPivot.transform.localEulerAngles = new Vector3(0, 0, 0);
            StepManager.Instance.Process("6.10");
            StepManager.Instance.SetStep("6.11");

        }
        else if (StepManager.Instance.currentStepId == "6.12")
        {
            plateHolderPivot.transform.localEulerAngles = new Vector3(0, 0, 0);
            StepManager.Instance.Process("6.12");
            StepManager.Instance.SetStep("6.13");
        }

        else
        {
            StepManager.Instance.Process(StepManager.Instance.currentStepId);
        }
        
    }
}
