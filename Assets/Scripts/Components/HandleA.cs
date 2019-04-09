using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleA : MonoBehaviour
{
    public ControllerGrabObject controllerGrabObject;
    public Material red;
    public Material grey;
    public GameObject cube;
    private bool doorIsOpen;
    public DoorB doorB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log(this.transform.localEulerAngles.x);
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            this.transform.rotation = Quaternion.Euler(350, 0, 0);
        }
       
    }

    public void HandleMove()
    {
        //需要写控制角度的方法
        //if(this.transform.localEulerAngles.x <= 350 && this.transform.localEulerAngles.x >= 260)
        {
            cube.GetComponent<Renderer>().material = red;
            doorB.isAviliable = false;
            this.transform.LookAt(new Vector3
                (this.transform.position.x, controllerGrabObject.transform.position.y, controllerGrabObject.transform.position.z));
        }
        if (this.transform.eulerAngles.x > 350 || this.transform.eulerAngles.x < 260)
        {
            cube.GetComponent<Renderer>().material = grey;
            doorB.isAviliable = true;
        }
        //else if (this.transform.localEulerAngles.x > 350)
        //{
        //    this.transform.rotation = Quaternion.Euler(320, 0, 0);
        //    Debug.Log("Ove r350" +this.transform.eulerAngles);
        //    //this.transform.eulerAngles = new Vector3(350, 0, 0);
        //    //this.transform.LookAt(new Vector3(350, controllerGrabObject.transform.position.y, controllerGrabObject.transform.position.z));
        //    //Debug.Log("Open?");
        //}
        //else if (this.transform.localEulerAngles.x < 260)
        //{
        //    Debug.LogWarning(this.transform.eulerAngles);
        //    this.transform.eulerAngles = new Vector3(260, 0, 0);

        //    this.transform.LookAt(new Vector3(260, controllerGrabObject.transform.position.y, controllerGrabObject.transform.position.z));
        //    Debug.Log("Close");
        //}

    }
}
