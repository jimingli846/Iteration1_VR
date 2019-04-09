using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//-------------------------------------------------------------------------
[RequireComponent(typeof(Interactable))]
public class InteractableTest : MonoBehaviour
{
    //private TextMesh textMesh;
    private Vector3 oldPosition;
    private Quaternion oldRotation;

    public GrabableSingleItem grabableSingleItem;
    public GrabableMultipleItem grabableMultipleItem;
    public GrabableCleaningItem grabableCleaningItem;
    public LoadLevelManager loadLevelManager;

    public GameObject replaceDestroyedObj;

    private float attachTime;

    public Text currentObjectTest;

    public StepManager stepManager;
    private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers);

    private bool bladeIsPositioned;
    private bool holderIsPositioned;

    public bool isMovable = true;
    public bool isForTouch;
    public bool isForMove;

    //-------------------------------------------------
    void Awake()
    {
        //textMesh = GetComponentInChildren<TextMesh>();
        //textMesh.text = "No Hand Hovering";
    }


    //-------------------------------------------------
    // Called when a Hand starts hovering over this object
    //-------------------------------------------------
    private void OnHandHoverBegin(Hand hand)
    {

        currentObjectTest.text = this.gameObject.name;
        //textMesh.text = "Hovering hand: " + hand.name;
    }


    //-------------------------------------------------
    // Called when a Hand stops hovering over this object
    //-------------------------------------------------
    private void OnHandHoverEnd(Hand hand)
    {
        currentObjectTest.text = null;
        //Debug.Log("HandHoverEnd");
        //textMesh.text = "No Hand Hovering";
    }


    //-------------------------------------------------
    // Called every Update() while a Hand is hovering over this object
    //-------------------------------------------------
    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetStandardInteractionButtonDown() || ((hand.controller != null) && hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)))
        {
            if (hand.currentAttachedObject != gameObject)
            {
                if(isForTouch)
                {
                    if(stepManager.stepColliderController.CheckTarget(this.gameObject))
                    {

                        //stepManager.stepColliderController.ProcessNext();
                        isForTouch = false;
                    }
                }
                else
                {
                    if(isMovable)
                    {
                        // Save our position/rotation so that we can restore it when we detach
                        oldPosition = transform.localPosition;
                        oldRotation = transform.rotation;
                        // Call this to continue receiving HandHoverUpdate messages,
                        // and prevent the hand from hovering over anything else
                        hand.HoverLock(GetComponent<Interactable>());
                        // Attach this object to the hand
                        hand.AttachObject(gameObject, attachmentFlags);
                        if(this.gameObject.tag == "Multiple")
                        {
                            //pick up multiple objects
                            if(stepManager.stepColliderController.CheckTarget(this.gameObject))
                            {
                                stepManager.stepColliderController.ProcessNext();
                                    
                            }
                        }

                        if(this.gameObject.tag == "Single")
                        {
                            //pick up single objects
                            if (stepManager.stepColliderController.CheckTarget(this.gameObject))
                            {
                                stepManager.stepColliderController.ProcessNext();
                            }
                        }
                        if(this.gameObject.tag == "LevelButton")
                        {
                            loadLevelManager.LoadLevel();
                        }

                        else if(this.gameObject.tag == "DestroyOnRelease")
                        {
                            if (StepManager.Instance.stepColliderController.CheckTarget(this.gameObject))
                            {
                                this.gameObject.SetActive(false);
                                replaceDestroyedObj.SetActive(true);
                            }
                        }
                    }
                    
                }
                
            }
            else
            {
                // Detach this object from the hand
                hand.DetachObject(gameObject);

                // Call this to undo HoverLock
                hand.HoverUnlock(GetComponent<Interactable>());

                if(this.gameObject.tag == "Single")
                {
                    //Debug.Log("SingleMove");
                    if (this.gameObject.name == "Build Plate")
                    {
                        grabableSingleItem.MovePlateToCorrectPosition();
                    }
                    else if(this.gameObject.name == "Mask")
                    {
                        grabableSingleItem.MoveMaskToCorrectPosition();
                    }
                    else
                    {
                        grabableSingleItem.MoveToCorrectPosition();
                    }
                    
                }
                if(this.gameObject.tag == "Multiple")
                {
                    grabableMultipleItem.MoveToCorrectPosition();
                }
                if(this.gameObject.tag == "Cleaner")
                {
                    grabableCleaningItem.MoveToCorrectPosition();
                }
                
                // Restore position/rotation
                //transform.position = oldPosition;
                //transform.rotation = oldRotation;
            }
        }
    }


    //-------------------------------------------------
    // Called when this GameObject becomes attached to the hand
    //-------------------------------------------------
    private void OnAttachedToHand(Hand hand)
    {
        //Debug.Log("AttachedToHand");
        //textMesh.text = "Attached to hand: " + hand.name;
        attachTime = Time.time;
    }


    //-------------------------------------------------
    // Called when this GameObject is detached from the hand
    //-------------------------------------------------
    private void OnDetachedFromHand(Hand hand)
    {
        //Debug.Log("Detach From Hand");
        //textMesh.text = "Detached from hand: " + hand.name;
    }


    //-------------------------------------------------
    // Called every Update() while this GameObject is attached to the hand
    //-------------------------------------------------
    private void HandAttachedUpdate(Hand hand)
    {
        //Debug.Log("Hand Attach Stay");
        //textMesh.text = "Attached to hand: " + hand.name + "\nAttached time: " + (Time.time - attachTime).ToString("F2");
    }


    //-------------------------------------------------
    // Called when this attached GameObject becomes the primary attached object
    //-------------------------------------------------
    private void OnHandFocusAcquired(Hand hand)
    {

    }


    //-------------------------------------------------
    // Called when another attached GameObject becomes the primary attached object
    //-------------------------------------------------
    private void OnHandFocusLost(Hand hand)
    {
    }
}

