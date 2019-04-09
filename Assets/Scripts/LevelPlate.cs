using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class LevelPlate : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform plateHolder;
    public float angularSpeed = 0.1f;
    public bool goingUp, goingDown, goingLeft, goingRight;
    float minRotation, maxRotation;
    Outline outline;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       // if (plateHolder.rotation.eulerAngles.x >= 0 && plateHolder.rotation.eulerAngles.x <= 1 && plateHolder.rotation.eulerAngles.y - 180 >= 0 && plateHolder.rotation.eulerAngles.y - 180 <= 1 && plateHolder.rotation.eulerAngles.z >= 0 && plateHolder.rotation.eulerAngles.z <= 1)
        {
            if (goingUp) { plateHolder.Rotate(angularSpeed * Time.deltaTime, 0, 0); }
            else if (goingDown) { plateHolder.Rotate(-angularSpeed * Time.deltaTime, 0, 0); }
            else if (goingLeft) { plateHolder.Rotate(0, 0, -angularSpeed * Time.deltaTime); }
            else if (goingRight) { plateHolder.Rotate(0, 0, angularSpeed * Time.deltaTime); }
        }

        //if (plateHolder.rotation.eulerAngles.x >= 0 && plateHolder.rotation.eulerAngles.y - 180 >= 0 && plateHolder.rotation.eulerAngles.z >= 0)
        //{

        //    minRotation = 0;
        //    maxRotation = 1;
        //}

        //else
        //{
        //    minRotation = 180;
        //    maxRotation = 179;
        //}
        //Vector3 currentRotation = plateHolder.transform.localRotation.eulerAngles;
        //currentRotation.x = Mathf.Clamp(currentRotation.x, minRotation, maxRotation);
        //currentRotation.y = Mathf.Clamp(currentRotation.y, minRotation, maxRotation);
        //currentRotation.z = Mathf.Clamp(currentRotation.z, minRotation, maxRotation);
        //plateHolder.transform.localRotation = Quaternion.Euler(currentRotation);

    }

    public void levelPlateUp(bool boolll)
    {
        goingUp = boolll;
    }
    public void levelPlateDown(bool boolll)
    {
        goingDown = boolll;
    }
    public void levelPlateLeft (bool boolll)
    {
        goingLeft = boolll;
    }
    public void levelPlateRight(bool boolll)
    {
        goingRight = boolll;
    }

    public void changeMatToGray(Renderer rend)
    {
        rend.material.color = Color.gray;
    }


    public void changeMatToWhite(Renderer rend)
    {
        rend.material.color = Color.white;
    }

    
}
