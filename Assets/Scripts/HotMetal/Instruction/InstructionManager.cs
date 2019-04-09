using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : Singleton<InstructionManager>
{
    private InstructionModel model;
    private InstructionPanel panel;
    private StepObject currentStep;

    private void Awake()
    {
        EventManager.Instance.AddEventHandler(EventManager.EVENT_STEP_START, StepStartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_STEP_PROCESS, StepProcessHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_STEP_INCOMPLETE, StepIncompleteHandler);
        panel = GetComponent<InstructionPanel>();
        model = GetComponent<InstructionModel>();
        model.init();
        panel.updateOperations(model.GetOperations());
    }

    private void StepIncompleteHandler()
    {
        panel.UpdateState();
    }

    private void StepProcessHandler()
    {
        panel.UpdateState();
    }

    private void StepStartHandler()
    {
        StepObject step = model.GetStep(StepManager.Instance.currentStepId);
        currentStep = step;
        panel.updateStep(step);
        panel.UpdateState();
    }

    public void NextButtonDown()
    {
        StepManager.Instance.NextStep();
    }

    public void AddCount()
    {
        currentStep.CurrentCount++;
        panel.updateCount(currentStep);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start?");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
