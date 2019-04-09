using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step75 : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    private float xmax = 0.19f;
    private float xmin = -0.09f;

    [SerializeField] GameObject spreadPowder;

    private bool left75, right75;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (targetObject.transform.localPosition.x >= xmax)
        {
            left75 = true;
        }

        if (targetObject.transform.localPosition.x <= xmin && left75)
        {
            right75 = true;
        }
        /*
        if (StepManager.Instance.currentStepId == "7.5" && left75 && right75)
        {
            StepManager.Instance.Process("7.5");
            left75 = false;
            right75 = false;
        }
        */

        if(StepManager.Instance.currentStepId == "7.5")
        {
            if(!spreadPowder.activeSelf)
                spreadPowder.SetActive(true);

            if (left75 && right75)
            {
                StepManager.Instance.Process("7.5");
                left75 = false;
                right75 = false;
            }
        }
    }
}
