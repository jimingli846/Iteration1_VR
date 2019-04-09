using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StepManager : Singleton<StepManager>
{
    public enum StepState {
        Incompleted,
        Completed,
        End
    };

    public StepColliderController stepColliderController;

    public delegate void SetStepHandler();
    public StepObject currentStepObject;
    public string currentStepId;
    public StepState currentState;

    public void SetStep(string stepId)
    {
        Debug.Log("SetStep: " + stepId);
        EventManager.Instance.SendEvent(EventManager.EVENT_STEP_END);
        EventManager.Instance.SendEvent(EventManager.EVENT_EACH_STEP_END + currentStepId);
        currentStepId = stepId;
        currentStepObject = InstructionModel.Instance.GetStep(stepId);
        currentState = StepState.Incompleted;
        EventManager.Instance.SendEvent(EventManager.EVENT_STEP_START);
        EventManager.Instance.SendEvent(EventManager.EVENT_EACH_STEP_START + stepId);

        if (currentStepObject.AutoProceed == 1)
        {
            Process(currentStepId);
        }
    }

    public void SetIncomplete(string stepId)
    {
        if (stepId == currentStepId)
        {
            currentState = StepState.Incompleted;
            EventManager.Instance.SendEvent(EventManager.EVENT_STEP_INCOMPLETE);
        }
    }

    public void Process(string stepId)
    {
        if (stepId == currentStepId)
        {
            if (currentStepObject.ShowNextButton == 1)
                currentState = StepState.Completed;
            else
                currentState = StepState.End;
            EventManager.Instance.SendEvent(EventManager.EVENT_STEP_PROCESS);
            if (currentState == StepState.End)
            {
                NextStep();
            }
        }

        SoundManager.Instance.playCompleteStep();
    }

    public void NextStep()
    {
        currentState = StepState.End;
        StepObject nextStep = InstructionModel.Instance.GetNextStep(currentStepId);
        if (nextStep != null)
        {
            SetStep(nextStep.Id);
        }
    }

    // Use this for initialization
    void Start()
    {
        SetStep("1.1");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetIncomplete(currentStepId);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Process(currentStepId);
        }
    }
}
