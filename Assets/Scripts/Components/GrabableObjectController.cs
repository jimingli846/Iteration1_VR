using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObjectController : MonoBehaviour
{
    public Transform originalTransform;
    public Transform destinyTransform;
    public bool isInPosition;
    // Start is called before the first frame update
    void Start()
    {
        //originalTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            this.transform.position = originalTransform.position;
        }
    }

    public void transformToOriginal()
    {
        Debug.Log("Back to Original Position");
        this.GetComponent<Rigidbody>().position = originalTransform.position;
        this.GetComponent<Rigidbody>().rotation = originalTransform.rotation;
        //this.GetComponent<Rigidbody>().useGravity = false;
    }

    public void transformToDestiny()
    {
        Debug.Log("Success To Destiny Position");
        this.GetComponent<Rigidbody>().rotation = destinyTransform.rotation;
        this.GetComponent<Rigidbody>().position = destinyTransform.position;
        Destroy(GetComponent<Rigidbody>());
    }
}
