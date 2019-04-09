using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorB : MonoBehaviour
{
    public Transform cube;
    public float angleY;

    public bool isAviliable;
    public bool isMoving;

    public bool isReturned;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //angleY = Mathf.Atan((cube.position.x - this.transform.position.x) / (cube.position.z - this.transform.position.z));
        //Debug.Log(angleY);
        //this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, angleY * 180 / Mathf.PI, this.transform.rotation.z);
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(this.transform.localEulerAngles);
        }
    }

    public void HandleMove()
    {
        if(isAviliable)
        {
            //angleY = ((cube.position.x - this.transform.position.x) / (cube.position.z - this.transform.position.z)) * 180 / Mathf.PI;
            //Debug.Log(angleY);
            //this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, (angleY), this.transform.rotation.z);


            //if (this.transform.localEulerAngles.y <= 355 && this.transform.localEulerAngles.y >= 270)
            //{
            //if (isMoving)
            //{
                angleY = Mathf.Atan((cube.position.x - this.transform.position.x) / (cube.position.z - this.transform.position.z));
                //this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, angleY * 180 / Mathf.PI, this.transform.rotation.z);
                //cube.GetComponent<Renderer>().material = red;
                //if (this.transform.localEulerAngles.y > 355)
                //{
                //    this.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, 350, this.transform.eulerAngles.z);
                //}
                float angY = angleY * 180 / Mathf.PI;
                //if (this.transform.eulerAngles.y > 355)
                //{
                //    angY = 355;
                //    Debug.LogWarning(angY);
                //    Debug.Log(this.transform.eulerAngles.y);
                //}
                this.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, angY, this.transform.eulerAngles.z);
            //if ((this.transform.localEulerAngles.y >= 355 && this.transform.localEulerAngles.y < 360) || (this.transform.localEulerAngles.y >= 0 && this.transform.localEulerAngles.y <= 20))
            if (this.transform.localEulerAngles.y >= 30 && this.transform.localEulerAngles.y <= 50)
                {
                    this.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, 30, this.transform.eulerAngles.z);
                }
                else if(this.transform.localEulerAngles.y >= 270 && this.transform.localEulerAngles.y <= 275)
                {
                this.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, 270, this.transform.eulerAngles.z);
                }
            //}


            //else
            //{
            //    this.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, 35, this.transform.eulerAngles.z);
            //    isReturned = true;
            //}
        }
        //需要写控制角度的方法
        //if(this.transform.localEulerAngles.x <= 350 && this.transform.localEulerAngles.x >= 260)
        
        //if (this.transform.eulerAngles.x > 350 || this.transform.eulerAngles.x < 260)
        //{
        //    cube.GetComponent<Renderer>().material = grey;
        //    doorB.isAviliable = true;
        //}

        
    }

    public void SetIsReturn()
    {
        this.gameObject.GetComponent<Collider>().enabled = false;
        isReturned = false;
    }
}