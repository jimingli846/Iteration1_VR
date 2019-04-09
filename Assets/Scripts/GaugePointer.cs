using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class GaugePointer : MonoBehaviour
{


    [SerializeField] GameObject gaugePivot, platformPivot, startPos, endPos; 
    

    bool canManipulate = false;
    bool done610, done612;

    Rigidbody rb;
    Rigidbody rbStart, rbEnd;

    private float forceVal = 600f, angularForce = 50000f, platformAngleForce = 0.01f;

    private float initialYValue, deltaY, veryInitialValue, initialValueStart, initialValueEnd;
    private Quaternion originalGaugeRot;

    private bool backPos = false, forPos = false;

    [SerializeField] private LinearMapping linearMapping;
    
    [SerializeField] LevelingButtons leftRecoater, rightRecoater;
    
    void Start()
    {

        linearMapping = this.GetComponent<LinearMapping>();
        rb = GetComponent<Rigidbody>();
        rbStart = startPos.GetComponent<Rigidbody>();
        rbEnd = endPos.GetComponent<Rigidbody>();


        initialYValue = transform.localPosition.y;
        veryInitialValue = initialYValue;

        initialValueStart = startPos.transform.localPosition.y;
        initialValueEnd = endPos.transform.localPosition.y;

        originalGaugeRot = gaugePivot.transform.localRotation;


    }
  
    void Update()
    {



        if (canManipulate)
        {
            deltaY = transform.localPosition.y - initialYValue;

            if (Mathf.Abs(deltaY) > 0.0001)
            {
                gaugePivot.transform.Rotate(0, 0, +(deltaY * angularForce));
                initialYValue = transform.localPosition.y;
            }

            
        }


        if (checkForZPosition() && StepManager.Instance.stepColliderController.currentStep == 69) //6.9
        {
            StepManager.Instance.stepColliderController.ProcessNext();
        }
        



        if (StepManager.Instance.stepColliderController.currentStep == 610) //6.10
        {
            if (platformPivot.transform.localRotation.eulerAngles.x >= 0.00 && platformPivot.transform.localRotation.eulerAngles.x < 0.05)
            {
                if (!done610)
                {
                    StepManager.Instance.Process("6.10");
                    done610 = true;
                }
                else { }
            }
            else
            {
                done610 = false;
                StepManager.Instance.SetIncomplete("6.10");
            }
        }

        if(leftRecoater.leftButton611 && rightRecoater.rightButton611 && StepManager.Instance.stepColliderController.currentStep == 611)        //6.11
        {
            StepManager.Instance.stepColliderController.ProcessNext();
        }

        
        if (StepManager.Instance.stepColliderController.currentStep == 612) //6.12
        {
            if (platformPivot.transform.localRotation.eulerAngles.z >= 0.00 && platformPivot.transform.localRotation.eulerAngles.z < 0.05)
            {
                if (!done612)
                {
                    StepManager.Instance.Process("6.12");
                    done612 = true;
                }
                else { }
            }
            else
            {
                done612 = false;
                StepManager.Instance.SetIncomplete("6.12");

            }
        }

        if (StepManager.Instance.currentStepId == "6.19")
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            MeshRenderer[] Meshes;

            Meshes = this.gameObject.GetComponentsInChildren<MeshRenderer>();

            foreach(MeshRenderer mesh in Meshes)
            {
                mesh.enabled = false;
            }
            StepManager.Instance.Process("6.19");
        }

    }

    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetStandardInteractionButtonDown() || ((hand.controller != null) && hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)))
        {
            if (StepManager.Instance.stepColliderController.currentStep == 67)
            {
                StepManager.Instance.stepColliderController.ProcessNext();
            }

        }
    }

    private bool checkForZPosition()
    {
 

        {
            if (linearMapping.value < 0.1)
                backPos = true;
            if (linearMapping.value > 0.8)
                forPos = true;
        }

        return backPos && forPos;
    }

    private bool checkIfIndicatorIsOnRecoater()
    {
        if (gameObject.transform.parent.transform.parent.gameObject.name.StartsWith("Recoater"))
            return true;

        else return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("PointerKinematicToggle"))
        {
            rb.isKinematic = false;
            rbStart.isKinematic = false;
            rbEnd.isKinematic = false;
            canManipulate = true;
            initialYValue = veryInitialValue;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.StartsWith("PointerKinematicToggle"))
        {
            rb.isKinematic = true;
            rbStart.isKinematic = true;
            rbEnd.isKinematic = true;
            canManipulate = false;
            initialYValue = veryInitialValue;
            transform.localPosition = new Vector3(transform.localPosition.x, veryInitialValue, transform.localPosition.z);
            startPos.transform.localPosition = new Vector3(startPos.transform.localPosition.x, initialValueStart, startPos.transform.localPosition.z);
            endPos.transform.localPosition = new Vector3(endPos.transform.localPosition.x, initialValueEnd, endPos.transform.localPosition.z);

            gaugePivot.transform.localRotation = originalGaugeRot;

         }
    }


}
