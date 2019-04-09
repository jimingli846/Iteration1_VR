using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class PickUpIndicator : MonoBehaviour
{
    private Vector3 oldPosition;
    private Quaternion oldRotation;
    
    private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers);

    public bool isInsideTrigger = false;

    [SerializeField] GameObject actualIndicator, indicatorTrigger;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "IndicatorTrigger")
        {
            isInsideTrigger = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "IndicatorTrigger")
        {
            isInsideTrigger = false;
        }
    }

    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetStandardInteractionButtonDown() || ((hand.controller != null) && hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)))
        {

            if (hand.currentAttachedObject != gameObject)
            {
                indicatorTrigger.SetActive(true);
                oldPosition = transform.localPosition;
                oldRotation = transform.localRotation;

                if (StepManager.Instance.currentStepId == "6.7")
                {
                    StepManager.Instance.Process(StepManager.Instance.currentStepId);
                }

                hand.HoverLock(GetComponent<Interactable>());

                hand.AttachObject(gameObject, attachmentFlags);

            }
            else
            {
                hand.DetachObject(gameObject);
                hand.HoverUnlock(GetComponent<Interactable>());

                if (isInsideTrigger)
                {
                    if (StepManager.Instance.currentStepId == "6.8")
                        StepManager.Instance.Process(StepManager.Instance.currentStepId);

                    actualIndicator.SetActive(true);
                    StartCoroutine(DestroyThis());
                    isInsideTrigger = false;
                }

                else
                {
                    transform.localPosition = oldPosition;
                    transform.localRotation = oldRotation;
                }
                
            }
        }
    }

    private IEnumerator DestroyThis()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        indicatorTrigger.GetComponent<BoxCollider>().enabled = false;

        indicatorTrigger.transform.parent = actualIndicator.transform;

        foreach (MeshRenderer mr in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            mr.enabled = false;
        }

        yield return null;

        //this.gameObject.SetActive(false);
        //indicatorTrigger.gameObject.SetActive(false);

    }
}
