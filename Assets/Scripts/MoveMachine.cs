using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMachine : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Vector3 originalPos;
    void Start()
    {
        originalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Keypad8)){
            transform.Translate(0, speed * Time.deltaTime, 0);
        }

        else if (Input.GetKey(KeyCode.Keypad5))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

        else if (Input.GetKey(KeyCode.Keypad4))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.Keypad6))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        else if (Input.GetKey(KeyCode.Keypad1))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.Keypad3))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.Keypad0))
        {
            transform.position = originalPos;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            StepManager.Instance.Process(StepManager.Instance.currentStepId);
        }
    }
}
