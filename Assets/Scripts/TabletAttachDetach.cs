using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TabletAttachDetach : MonoBehaviour
{
    [SerializeField] Transform attachTransform, detachTransform;
    [SerializeField] BoxCollider boxCollider;

    //private SteamVR_TrackedController _controller;

    bool isAttachedToHand = true;

    bool hidingPanelNow = false;
    bool panelHiddenNow = false;
    bool showingPanelNow = false;

    [SerializeField] public Hand hand;
    

    private Vector3 scale;

    void Start()
    {
        scale = transform.localScale;
        boxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (hand != null)
        {
            if (hand.controller.GetHairTriggerDown() && isAttachedToHand && !panelHiddenNow)
            {
                removeHandParent();
                isAttachedToHand = false;
                boxCollider.enabled = true;
               // SoundManager.Instance.isAttachedToTablet = false;
            }

            if (hand.controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                if (!panelHiddenNow)
                {
                    hidingPanelNow = true;
                    SoundManager.Instance.playHideShow();
                }
                else
                {
                    showingPanelNow = true;
                    SoundManager.Instance.playHideShow();
                }
            }
        }
        if (isAttachedToHand)
        {
            if (hidingPanelNow && !panelHiddenNow)
            {
                transform.localPosition += new Vector3(0, -0.01f, 0);


                if (transform.localScale.x >= 0f && transform.localScale.z >= 0f && transform.localScale.y >= 0f)
                {
                    transform.localScale -= new Vector3(0.005f, 0.005f, 0.005f);
                }
                else
                {
                    transform.localScale = Vector3.zero;
                    hidingPanelNow = false;
                    panelHiddenNow = true;
                    hand.hoverLayerMask = -1;       //Everything
                }
            }

            else if (panelHiddenNow && showingPanelNow)
            {
                transform.localPosition += new Vector3(0, 0.01f, 0);

                if (transform.localScale.x <= scale.x && transform.localScale.z <= scale.x && transform.localScale.y <= scale.y)
                {
                    transform.localScale += new Vector3(0.005f, 0.005f, 0.005f);
                }
                else
                {
                    transform.localPosition += new Vector3(0, 0.01f, 0);
                    showingPanelNow = false;
                    panelHiddenNow = false;
                    hand.hoverLayerMask = 0;        //Nothing
                }
            }
        }

        detachTransform.position = transform.position;
        detachTransform.rotation = transform.rotation;
        transform.LookAt(Camera.main.transform);
        transform.rotation *= Quaternion.Euler(-120, 180, 0);
    }



    public void makeHandParent()
    {
        if (!isAttachedToHand)
        {
            transform.parent = hand.transform;
            transform.localPosition = attachTransform.localPosition;
            transform.localRotation = attachTransform.localRotation;
            GameObject.Find("InstructionCollider").GetComponent<BoxCollider>().enabled = false;
            GetComponent<InteractableButtonEvents1>().enabled = false;
            hand.hoverLayerMask = 0;        //Nothing
            isAttachedToHand = true;
           // SoundManager.Instance.isAttachedToTablet = true;

        }
    }

    public void removeHandParent()
    {
        transform.parent = GameObject.Find("MachineDemo").transform;
        transform.localPosition = detachTransform.localPosition;
        transform.localRotation = detachTransform.localRotation;
        GameObject.Find("InstructionCollider").GetComponent<BoxCollider>().enabled = true;
        hand.hoverLayerMask = -1;        //Everything
    }

    private void HidePanelNow()
    {
        
    }

    private void ShowPanelNow()
    {
        while (transform.localScale.x < scale.x && transform.localScale.z < scale.x)
        {
            transform.localScale += new Vector3(0.005f, 0, 0.005f);
        }
    }
}
