using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableSingleItem : MonoBehaviour
{
    public Vector3 origPos;
    public Quaternion origRot;

    public Vector3 targPos;
    public Quaternion targRot;

    public GameObject targetTrigger;
    public NextStepTriggerController nextStepTriggerController;
    public bool isMoving;

    public GameObject plateParent;
    public StepManager stepManager;

    // Start is called before the first frame update
    void Start()
    {
        origPos = this.transform.localPosition;
        origRot = this.transform.rotation;

        targPos = origPos;
        targRot = origRot;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            //after target object is located in the target position(called every frame)
            this.transform.position = targetTrigger.transform.position;
            this.transform.rotation = targetTrigger.transform.rotation;
        }
    }

    public void MoveToCorrectPosition()
    {
        if (targetTrigger.GetComponent<GrabableSingleItemTrigger>().isInTrigger)
        {
            //target object directly move to target position(called once)
            this.transform.position = targetTrigger.transform.position;
            this.transform.rotation = targetTrigger.transform.rotation;
            isMoving = true;
            this.GetComponent<Collider>().enabled = false;
            targetTrigger.GetComponent<Collider>().enabled = false;
            if(this.gameObject.name == "Filter" && stepManager.currentStepId == "7.10")
            {
                stepManager.Process("7.10");
            }
            else
            {
                stepManager.stepColliderController.ProcessNext();
            }
        }
        else
        {
            //target object move back to original position(called once)
            this.transform.localPosition = origPos;
            this.transform.rotation = origRot;
        }

    }

    public void MoveMaskToCorrectPosition()
    {
        if (targetTrigger.GetComponent<GrabableSingleItemTrigger>().isInTrigger)
        {
            //target object directly move to target position(called once)
            this.transform.position = targetTrigger.transform.position;
            this.transform.rotation = targetTrigger.transform.rotation;
            this.GetComponent<Collider>().enabled = false;
            targetTrigger.GetComponent<Collider>().enabled = false;
            if(stepManager.currentStepId == "7.7")
            {
                stepManager.Process("7.7");
                this.GetComponent<LensCleaningManager>().LineAEnable();
            }
            else if(stepManager.currentStepId == "7.9")
            {
                stepManager.Process("7.9");
            }
        }
        else
        {
            //target object move back to original position(called once)
            this.transform.localPosition = origPos;
            this.transform.rotation = origRot;
        }

    }


    public void MovePlateToCorrectPosition()
    {
        if (targetTrigger.GetComponent<GrabableSingleItemTrigger>().isInTrigger)
        {
            Debug.Log("Plate Move");
            //target object directly move to target position(called once)
            this.transform.position = targetTrigger.transform.position;
            this.transform.rotation = targetTrigger.transform.rotation;
            this.transform.parent = plateParent.transform;
            //isMoving = true;
            this.GetComponent<Collider>().enabled = false;
            //this.GetComponent<Renderer>().material.color = Color.cyan;
            targetTrigger.GetComponent<Collider>().enabled = false;
            nextStepTriggerController.EnableNextStepColliders();
            stepManager.stepColliderController.ProcessNext();
        }
        else
        {
            //target object move back to original position(called once)
            this.transform.localPosition = origPos;
            this.transform.rotation = origRot;
        }

    }
}
