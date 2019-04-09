using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using cakeslice;

public class HintOnOff : MonoBehaviour
{
    [SerializeField] Text hintText;
    Hand hand;
    Camera cam;

    bool hintsShown = true;

    GameObject[] renderTypes;
    Material[] materials;
    Renderer[] renderers;
    [SerializeField] Material newMat;
    

    void Start()
    {
        hand = GetComponent<TabletAttachDetach>().hand;
        cam = Camera.main;
        renderTypes = GameObject.FindGameObjectsWithTag("EmissionMaterial");

        for(int i = 0; i< renderTypes.Length; i++)
        {
            materials[i] = renderTypes[i].GetComponent<Material>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hand != null)
        {
            if (hand.controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                cam.gameObject.GetComponent<OutlineEffect>().enabled = !cam.gameObject.GetComponent<OutlineEffect>().enabled;

                if (!hintsShown)
                    EventManager.Instance.SendEvent(EventManager.EVENT_START_GLOW);
                else
                    EventManager.Instance.SendEvent(EventManager.EVENT_STOP_GLOW);

                hintsShown = !hintsShown;


                if (cam.gameObject.GetComponent<OutlineEffect>().enabled)
                {
                    hintText.text = "Hints: Shown";
                }
                else hintText.text = "Hints: Hidden";
            }
        }

 

        

    }

    /*
    void HighlightOn()
    {
        for(int i = 0; i < renderTypes.Length; i++){
            renderTypes[i].GetComponent<Renderer>().material = materials[i];
        }
    }

    void HighlightOff()
    {
        glowEffect.glowMaterial.SetColor("_EmissionColor", Color.black*0);
        for (int i = 0; i < renderTypes.Length; i++)
        {
            renderTypes[i].GetComponent<Renderer>().material = newMat;
        }
    }*/

}
