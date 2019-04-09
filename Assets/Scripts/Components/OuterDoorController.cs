using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterDoorController : MonoBehaviour
{
    public bool isOpen;
    public bool isClicked;
    public float rotateSpeed;
    public float minEulerAngle;
    public float maxEulerAngle;
    public StepManager stepManager;
    public Collider outDoorCollider;
    public Collider handleCollider;
    public Collider chamberDoorCollider;
    public Collider recoaterCollider;
    void Update()
    {
        if(isClicked)
        {
            if(this.gameObject.name == "outerdoor" )
            {
                OuterDoor();
            }
            else if(this.gameObject.name == "ChamberSwitch")
            {
                Switch();
            }
            else if(this.gameObject.name == "ChamberDoor")
            {
                ChamberDoor();
            }
        }
    }
    public void DoorInteraction()
    {
        isClicked = true;
    }
    private void ChamberDoor()
    {
        if (!isOpen)
        {
            if (this.transform.eulerAngles.y < maxEulerAngle)
            {
                this.transform.Rotate(new Vector3(0, rotateSpeed, 0));
                if (this.transform.eulerAngles.y >= maxEulerAngle)
                {
                    isClicked = false;
                    isOpen = true;
                    if (stepManager.currentStepId == "4.2")
                    {
                        stepManager.Process("4.2");
                        recoaterCollider.enabled = true;
                    }
                    if (stepManager.currentStepId == "7.6")
                    {
                        stepManager.Process("7.6");
                    }
                    if (stepManager.currentStepId == "11.1")
                    {
                        stepManager.Process("11.1");
                    }
                }
            }
        }
        else
        {
            if (this.transform.eulerAngles.y > minEulerAngle)
            {
                this.transform.Rotate(new Vector3(0, -rotateSpeed, 0));
                if (this.transform.eulerAngles.y <= minEulerAngle)
                {
                    isClicked = false;
                    isOpen = false;
                    handleCollider.enabled = true;
                    if (stepManager.currentStepId == "7.4")
                    {
                        stepManager.Process("7.4");
                    }
                    if (stepManager.currentStepId == "7.11")
                    {
                        stepManager.Process("7.11");
                    }
                }
            }
        }
    }
    
    public void OuterDoor()
    {
        if (!isOpen)
        {
            if (this.transform.eulerAngles.y < maxEulerAngle)
            {
                this.transform.Rotate(new Vector3(0, rotateSpeed, 0));
                if (this.transform.eulerAngles.y >= maxEulerAngle)
                {
                    isClicked = false;
                    isOpen = true;
                    handleCollider.enabled = true;
                    if (stepManager.currentStepId == "3.9")
                    {
                        stepManager.Process("3.9");
                    }
                }
            }
        }
        else
        {
            if (this.transform.eulerAngles.y > minEulerAngle)
            {
                this.transform.Rotate(new Vector3(0, -rotateSpeed, 0));
                if (this.transform.eulerAngles.y <= minEulerAngle)
                {
                    handleCollider.enabled = false;
                    isClicked = false;
                    isOpen = false;
                }
            }
        }
    }

    public void Switch()
    {
        if (!isOpen)
        {
            if (this.transform.localRotation.x < maxEulerAngle)
            {
                this.transform.Rotate(new Vector3(rotateSpeed, 0, 0));
                if (this.transform.localRotation.x >= maxEulerAngle)
                {
                    isClicked = false;
                    isOpen = true;
                    chamberDoorCollider.enabled = true;
                    outDoorCollider.enabled = false;
                    if (stepManager.currentStepId == "4.1")
                    {
                        stepManager.Process("4.1");
                    }
                }
            }
        }
        else
        {
            if (this.transform.localRotation.x > minEulerAngle)
            {
                this.transform.Rotate(new Vector3(-rotateSpeed, 0, 0));
                if (this.transform.localRotation.x <= minEulerAngle)
                {
                    isClicked = false;
                    isOpen = false;
                    outDoorCollider.enabled = true;
                    chamberDoorCollider.enabled = false;
                }
            }
        }
    }

}
