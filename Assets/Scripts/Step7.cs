using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step7 : MonoBehaviour
{
    // Start is called before the first frame update
    

    bool lensCleaned;
    bool gasExtractorNozzle;

    public GameObject mask1stTrigger;
    public GameObject mask2ndTrigger;

    public GrabableSingleItem grabableSingleItem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StepManager.Instance.currentStepId == "7.9" && gasExtractorNozzle)
        {
            StepManager.Instance.Process("7.9");
            gasExtractorNozzle = false;
        }
    }

    public void ChangeMaskTarget()
    {
        grabableSingleItem.gameObject.GetComponent<Collider>().enabled = true;
        grabableSingleItem.origPos = mask1stTrigger.transform.localPosition;
        grabableSingleItem.origRot = mask1stTrigger.transform.rotation;
        mask2ndTrigger.SetActive(true);
        grabableSingleItem.targetTrigger = mask2ndTrigger;
    }

    public void DoorClosed()
    {
        if(StepManager.Instance.currentStepId == "7.4")
            StepManager.Instance.Process("7.4");

        else if (StepManager.Instance.currentStepId == "7.11")
            StepManager.Instance.Process("7.11");
    }

    public void DoorOpen76()
    {
        if (StepManager.Instance.currentStepId == "7.6")
        {
            StepManager.Instance.Process("7.6");
        }
    }
}
