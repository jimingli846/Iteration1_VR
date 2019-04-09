using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using cakeslice;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class RayCastController : MonoBehaviour
{

    private SteamVR_TrackedObject trackedObj;

    private Hand _hand;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private SteamVR_LaserPointer laser;
    private GameObject actualLaser;

    private bool laserEnabled = false;

    [SerializeField] private GameObject quad;

    private TextMesh txt;

    private cakeslice.Outline outline;

    private OutlineEffect outlineEffect;

    private GameObject currentObj = null;


    RaycastHit hit;

    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        laser = GetComponent<SteamVR_LaserPointer>();
        hit =  new RaycastHit();
        txt = GetComponentInChildren<TextMesh>();
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        if(laser.holder != null)
            actualLaser = laser.holder;

        if (laserEnabled)
        {
            HighlightObject();
        }

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            laser.enabled = true;
            laserEnabled = true;
            actualLaser.SetActive(true);
        }

        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            actualLaser.SetActive(false);
            laserEnabled = false;
            if (currentObj != null && outline!=null)
            {
                outline.enabled = false;
            }

            quad.SetActive(false);
            txt.text = "";
        }
    }

    void HighlightObject()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out hit, 5000f))
        {

            if(currentObj!=null && hit.collider.gameObject != currentObj && outline != null)
            {
                outline.enabled = false;
            }

            if (hit.collider.attachedRigidbody)
            {
                currentObj = hit.collider.gameObject;
                quad.SetActive(true);
                txt.text = "The object selected is :\n" +currentObj.name;
                if (outline != null)
                {
                    outline = currentObj.GetComponent<cakeslice.Outline>();
                    outline.enabled = true;
                }
                Controller.TriggerHapticPulse(50);

            }
            else
            {
                if (currentObj != null)
                {
                    if(outline != null)
                        outline.enabled = false;
                    currentObj = null;
                }
                quad.SetActive(false);
                txt.text = "";
            }
            
        }
    }
}
