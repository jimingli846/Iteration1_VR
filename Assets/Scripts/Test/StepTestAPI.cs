using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTestAPI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "5.5", stepAStartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "5.5", stepAEndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "5.6", stepBStartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "5.6", stepBEndHandler);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void stepAStartHandler()
    {
        Debug.Log("5.5 start");
    }

    void stepAEndHandler()
    {
        Debug.Log("5.5 ends");
    }

    void stepBStartHandler()
    {
        Debug.Log("5.6 start");
    }

    void stepBEndHandler()
    {
        Debug.Log("5.6 ends");
    }
}
