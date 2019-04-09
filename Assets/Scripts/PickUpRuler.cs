using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class PickUpRuler : MonoBehaviour
{
    private Vector3 oldPosition;
    private Quaternion oldRotation;

    private bool objectPickUp;
    float startTime;

    bool triggerAnimationForBuildMesh = false;

    Quaternion parentTransform;

    private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers);


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name == "BuildMesh" && triggerAnimationForBuildMesh)
        {
            transform.parent.Rotate(0, 0, 800 * Time.deltaTime);
            transform.parent.Translate(0, 0.2f * Time.deltaTime, 0.2f * Time.deltaTime);
        }
    }

    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetStandardInteractionButtonDown() || ((hand.controller != null) && hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)))
        {

            if (hand.currentAttachedObject != gameObject)
            {
                oldPosition = transform.localPosition;
                oldRotation = transform.localRotation;

                hand.HoverLock(GetComponent<Interactable>());

                hand.AttachObject(gameObject, attachmentFlags);


            }
            else
            {
                hand.DetachObject(gameObject);
                hand.HoverUnlock(GetComponent<Interactable>());
                transform.localPosition = oldPosition;
                transform.localRotation = oldRotation;

                if (this.gameObject.name == "BuildMesh")
                {
                    startTime = Time.time;
                    triggerAnimationForBuildMesh = true;
                    transform.parent = GameObject.Find("BuildMeshPivot").transform;
                    parentTransform = transform.parent.rotation;
                    StartCoroutine("BuildMeshCo");
                }

                
            }
        }
    }

    private IEnumerator BuildMeshCo()
    {
        yield return new WaitForSeconds(10f);
        triggerAnimationForBuildMesh = false;
        GetComponent<BoxCollider>().enabled = false;

        transform.parent.rotation = parentTransform;
    }


}
