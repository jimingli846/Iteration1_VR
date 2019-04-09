using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

	// Use this for initialization
	private SteamVR_TrackedObject trackedObj;

	public GameObject collidingObject; 
	private GameObject objectInHand;
  
    public HandleA handleA;
    public DoorB doorB;

    public SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	private void SetCollidingObject(Collider col)
	{
		// 1
		if (collidingObject || !col.GetComponent<Rigidbody>())
		{
			return;
		}
		collidingObject = col.gameObject;
	}
    
	// Update is called once per frame
	void FixedUpdate () {

        
        if (Controller.GetHairTriggerDown())
	    {
		    if (collidingObject)
		    {
                if(collidingObject.tag == "Button")
                {
                    //send message of being clicked once
                    collidingObject.GetComponent<Renderer>().material.color = Color.yellow;
                }
                if(collidingObject.tag == "Handle")
                {
                    //collidingObject.GetComponent<HandleA>().isControlled = true;
                }
                else
                {
                    GrabObject();
                }
		    }
	    }
        
        if (Controller.GetHairTriggerUp())
        {
            if (collidingObject)
            {
                if (collidingObject.tag == "PressButton")
                {
                    //send message of click over once
                    collidingObject.GetComponent<PressButtonController>().isClicked = true;
                    collidingObject.GetComponent<Renderer>().material.color = Color.gray;
                }
                if (collidingObject.tag == "Handle")
                {

                    //collidingObject.GetComponent<HandleA>().isControlled = false;
                }
                else
                {
                    ReleaseObject();
                    
                }
		        
            }
        }

    }






    public void LookAtController()
    {
        collidingObject.transform.LookAt(this.transform.position);
    }



    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
        
    }

    // 2
	public void OnTriggerStay(Collider other)
	{
		SetCollidingObject(other);
        if (Controller.GetHairTrigger())
        {
            if (collidingObject.name == "Handle")
            {
                handleA.HandleMove();
            }
            if(collidingObject.name == "DoorReel")
            {
                doorB.HandleMove();
            }
            if(collidingObject.tag == "HoldButton")
            {
                collidingObject.GetComponent<HoldButtonController>().ButtonAction();
                collidingObject.GetComponent<Renderer>().material.color = Color.yellow;
            }
        }

        if(Controller.GetHairTriggerUp())
        {
            if (collidingObject.tag == "HoldButton")
            {
                collidingObject.GetComponent<Renderer>().material.color = Color.gray;
            }
        }

       
	}

	// 3
	public void OnTriggerExit(Collider other)
	{
		if (!collidingObject)
		{
			return;
		}

		collidingObject = null;
	}

	private void GrabObject()
    {
    // 1
	
	Debug.Log("The collindingObject is "+collidingObject+ " and the objectInHand is"+objectInHand);
    objectInHand = collidingObject;
    
    // 2
    var joint = AddFixedJoint();
    joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
	
	//ItemManager.ItemInstance.checkTag(objectInHand);
	
	
    }

    // 3
	private FixedJoint AddFixedJoint()
	{
		FixedJoint fx = gameObject.AddComponent<FixedJoint>();
		fx.breakForce = 20000;
		fx.breakTorque = 20000;
		return fx;
	}

	private void ReleaseObject()
	{
		// 1
		if (GetComponent<FixedJoint>())
		{
			// 2
			GetComponent<FixedJoint>().connectedBody = null;
			Destroy(GetComponent<FixedJoint>());

            if(objectInHand.GetComponent<GrabableObjectController>().isInPosition)
            {
                objectInHand.GetComponent<GrabableObjectController>().transformToDestiny();
            }
            else
            {
                objectInHand.GetComponent<GrabableObjectController>().transformToOriginal();
            }
			// 3
			//objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
			//objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
		}
		// 4
		objectInHand = null;
	}

    
    
}
