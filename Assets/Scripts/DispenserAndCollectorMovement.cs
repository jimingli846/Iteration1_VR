using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispenserAndCollectorMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 disPos, colPos;

    float minHeight = -0.0338f;
    float maxHeight;

    public float speed;

    float dispenserUp, dispenserDown, collectorUp, collectorDown;

    bool establishedConditions, buildHasStarted;

    bool processed71 = false;

    [SerializeField] GameObject dispenser, collector;

    public DissolveYIncrement process;

    int c = 0;

    void Awake()
    {
        maxHeight = dispenser.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        disPos = dispenser.transform.localPosition;
        colPos = collector.transform.localPosition;

        disPos.y = Mathf.Clamp(dispenser.transform.localPosition.y, minHeight, maxHeight);
        colPos.y = Mathf.Clamp(collector.transform.localPosition.y, minHeight, maxHeight);

        dispenser.transform.localPosition = disPos;
        collector.transform.localPosition = colPos;


        switch (c)
        {
            case 0:
                break;

            case 1:                                                                                         //DispenserUp
                dispenser.transform.Translate(0, speed * Time.deltaTime, 0);
                break;

            case 2:                                                                                         //DispenserDown
                dispenser.transform.Translate(0, -speed * Time.deltaTime, 0);
                break;

            case 3:                                                                                         //Collector Up
                collector.transform.Translate(0, speed * Time.deltaTime, 0);
                break;

            case 4:                                                                                        //Collector Down
                collector.transform.Translate(0, -speed * Time.deltaTime, 0);
                break;
                    
            case 5:                                                                                        //Establish Conditions
                if(!establishedConditions) { establishedConditions = true; }
                break;

            case 6:                                                                                        //Start Build
                if (!buildHasStarted && StepManager.Instance.currentStepId == "8.1")   { buildHasStarted = true; process.enabled = true; }
                break;

            default:
                break;
        }

        if(StepManager.Instance.currentStepId == "7.1")
        {
            if (dispenser.transform.localPosition.y <= minHeight && collector.transform.localPosition.y <= minHeight && !processed71)
            {
                StepManager.Instance.Process("7.1");
                processed71 = true;
            }
        }

        if (StepManager.Instance.currentStepId == "7.12")
        {
            if (establishedConditions)
            {
                StepManager.Instance.Process("7.12");
                establishedConditions = false;
            }
        }

        if (StepManager.Instance.currentStepId == "8.1")
        {
            if (buildHasStarted)
            {
                StepManager.Instance.Process("8.1");
                buildHasStarted = false;
            }
        }


    }

    public void movementSwitch(int num)
    {
        c = num;
    }

}
