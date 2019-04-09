using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableSingleItemTrigger : MonoBehaviour
{
    public StepColliderController stepColliderController;
    public bool isScroll;
    public bool isInTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isScroll)
        {
            isInTrigger = true;
        }
        //Controller enter target trigger
        if(isScroll && stepColliderController.CheckTarget(other.gameObject))
        {
           isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Controller exit target trigger
        if(!isScroll)
        {
            isInTrigger = false;
        }
        if (isScroll&& stepColliderController.CheckTarget(other.gameObject))
        {
            isInTrigger = false;    
        }
            
    }
}
