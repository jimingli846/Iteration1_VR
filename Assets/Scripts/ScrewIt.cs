using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class ScrewIt : MonoBehaviour
{
    public float screwSpeed = 10f;
    public float moveDownSpeed = 1f;

    private bool isScrewing = false;

    public bool hasCollided = false;

    private Rigidbody rb;
    

    private Vector3 originalPos;

    private Transform originalTransform;

    [SerializeField] private GameObject screwPrefab;
   

    BoxCollider bottomTrigger, topTrigger;
    MeshCollider screwTrigger;

    bool detachObjNow = false;

    Quaternion rot; 
    void Start()
    {
        originalTransform = GetComponent<Transform>();
        originalPos = transform.position;
        screwTrigger = GetComponent<MeshCollider>();
        bottomTrigger = transform.GetChild(0).GetComponent<BoxCollider>();
        topTrigger = transform.GetChild(1).GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();

        rot = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (hasCollided && !isScrewing) //When bottom trigger is hit and it is already not screwing
        {
            isScrewing = true;          //Start screwing
            bottomTrigger.enabled = false; //Disable bottom trigger
            rb.isKinematic = true;      //Make it kinematic
            screwTrigger.enabled = false;   //Disable trigger on body of screw  
            detachObjNow = true;

        }

        else if (isScrewing)
        {
            transform.Rotate(0, screwSpeed, 0);
            transform.Translate(0, -moveDownSpeed * Time.deltaTime, 0);

            if (!hasCollided)       //When top trigger is hit
            {
                isScrewing = false;
                topTrigger.enabled = false;
                rb.isKinematic = true;      //Make it kinematic


            }
        }



    }

    public void printThis()
    {
    }


    private void HandAttachedUpdate(Hand hand)
    {
        if (!hand.GetStandardInteractionButton())
        {
            if (detachObjNow)
                hand.DetachObject(this.gameObject, true);
            else
            {
                transform.position = originalPos;
            }
        }
    }
}
