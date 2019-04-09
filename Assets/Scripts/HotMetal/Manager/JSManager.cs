using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSManager : Singleton<JSManager>
{
    public void Awake()
    {
        //EventManager.Instance.AddEventHandler(EventManager.EVENT_CLICK_ITEM, ClickHandler);
    }

    public void ClickHandler()
    {
        //Application.ExternalCall("clickObject", InstructionModel.Instance.interactObject.name);
    }

    public void SetStep(string stepId)
    {
        Debug.Log("JSManager.SetStep: " + stepId);
        StepManager.Instance.SetStep(stepId);
    }

    public void LoadComplete()
    {
        Debug.Log("Try to connect to Javascript.");
        Application.ExternalCall("loadComplete");
    }
}
