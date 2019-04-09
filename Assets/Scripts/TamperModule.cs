using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamperModule : MonoBehaviour
{
    int numberOfTamps = 0;
    bool stepComplete = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfTamps > 7 && !stepComplete)
        {
            stepComplete = true;
        }

        if (StepManager.Instance.currentStepId == "7.3")
        {
            if (stepComplete)
                StepManager.Instance.Process("7.3");
            else StepManager.Instance.SetIncomplete("7.3");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("FakePowder"))
        {
            numberOfTamps++;
        }
    }


}
