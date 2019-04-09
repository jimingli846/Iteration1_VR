using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableMultipleItem : MonoBehaviour
{
    public Vector3 origPos;
    public Quaternion origRot;

    public Vector3 targPos;
    public Quaternion targRot;

    public GameObject[] targetTriggers;
    private bool findTrigger;
    private GameObject moveWithTrigger = null;
    public ScrewCounter screwCounter;
    public StepManager stepManager;

    // Start is called before the first frame update
    void Start()
    {
        origPos = this.transform.localPosition;
        origRot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(findTrigger)
        {
            //after target object is located in the target position(called every frame)
            this.transform.position = moveWithTrigger.transform.position;
            this.transform.rotation = moveWithTrigger.transform.rotation;
        }
    }
    public void MoveToCorrectPosition()
    {
        findTrigger = false;
        foreach(GameObject targetTrigger in targetTriggers)
        {
            if(targetTrigger.GetComponent<GrabableSingleItemTrigger>().isInTrigger)
            {
                //target object directly move to target position(called once)
                this.transform.position = targetTrigger.transform.position;
                this.transform.rotation = targetTrigger.transform.rotation;
                findTrigger = true;
                this.GetComponent<Collider>().enabled = false;
                //this.GetComponent<Renderer>().material.color = Color.cyan;
                targetTrigger.GetComponent<Collider>().enabled = false;
                targetTrigger.GetComponent<GrabableSingleItemTrigger>().isInTrigger = false;
                moveWithTrigger = targetTrigger;
                InstructionManager.Instance.AddCount();
                screwCounter.screwCount += 1;
                break;
            }
        }
        if(!findTrigger)
        {
            //target object move back to original position(called once)
            this.transform.localPosition = origPos;
            this.transform.rotation = origRot;
        }
    }
}
