using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelingButtons : MonoBehaviour
{
    public bool isGoingUp;
    public bool isGoingDown;
    public bool isGoingLeft;
    public bool isGoingRight;

    public GameObject targetObject;
    public float moveSpeed = 0.1f;

    public Text currentObjectText;

    public StepManager stepManager;
    public bool downButtonIsPressed;
    public bool leftButtonIsPressed, rightButtonIsPressed;

    public bool leftButton611, rightButton611;

    private bool left75, right75;


    private float ymax = 0.015f;
    private float ymin = -0.00643f;

    private float xmax = 0.2f;
    private float xmin = -0.1f;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isGoingUp)
        {
            targetObject.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            currentObjectText.text = "Plate Up Button";
            if (targetObject.transform.localPosition.y > ymax)
            {
                targetObject.transform.localPosition = new Vector3(targetObject.transform.localPosition.x, ymax, targetObject.transform.localPosition.z);
            }
        }
        if (isGoingDown)
        {
            targetObject.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            currentObjectText.text = "Plate Down Button";
            if (targetObject.transform.localPosition.y < ymin)
            {
                targetObject.transform.localPosition = new Vector3(targetObject.transform.localPosition.x, ymin, targetObject.transform.localPosition.z);

            }

            if (targetObject.transform.localPosition.y <= ymin && !downButtonIsPressed && StepManager.Instance.currentStepId == "6.5")
            {
                Debug.Log("Reach down limitation");
                stepManager.stepColliderController.ProcessNext();
                downButtonIsPressed = true; 
            }
        }


        if (isGoingLeft)
        {
            targetObject.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            currentObjectText.text = "Plate Left Button";

            if (targetObject.transform.localPosition.x > xmax)
            {
                targetObject.transform.localPosition = new Vector3(xmax, targetObject.transform.localPosition.y, targetObject.transform.localPosition.z);
            }
            if (targetObject.transform.localPosition.x >0.06f && !leftButtonIsPressed)
            {
                Debug.Log("Reach left limitation");
                stepManager.stepColliderController.ProcessNext();
                leftButtonIsPressed = true;
                leftButton611 = true;
            }

        }
        if (isGoingRight)
        {
            targetObject.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            currentObjectText.text = "Plate Right Button";
            rightButtonIsPressed = true;
            rightButton611 = true;
            if (targetObject.transform.localPosition.x < xmin)
            {
                targetObject.transform.localPosition = new Vector3(xmin, targetObject.transform.localPosition.y, targetObject.transform.localPosition.z);
            }
        }

        if ( leftButtonIsPressed && rightButtonIsPressed && stepManager.stepColliderController.currentStep == 611)  //6.11
        {
            stepManager.stepColliderController.ProcessNext();
            leftButtonIsPressed = false;
            rightButtonIsPressed = false;
        }

        
    }

    public void IsInUp()
    {
        isGoingUp = true;
        isGoingDown = false;
        isGoingLeft = false;
        isGoingRight = false;
        if(stepManager.currentStepId == "6.18")
        {
            stepManager.Process("6.18");
        }
    }

    public void IsInDown()
    {
        isGoingUp = false;
        isGoingDown = true;
        isGoingLeft = false;
        isGoingRight = false;
    }

    public void IsInLeft()
    {
        isGoingUp = false;
        isGoingDown = false;
        isGoingLeft = true;
        isGoingRight = false;
    }

    public void IsInRight()
    {
        isGoingUp = false;
        isGoingDown = false;
        isGoingLeft = false;
        isGoingRight = true;
    }

    public void IsOut()
    {
        isGoingUp = false;
        isGoingDown = false; ;
        isGoingLeft = false;
        isGoingRight = false;
    }

}
