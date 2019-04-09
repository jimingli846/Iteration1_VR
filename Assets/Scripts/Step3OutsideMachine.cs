using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step3OutsideMachine : MonoBehaviour
{
    bool machine;
    bool fineFilter;
    bool preFrilter;
    bool processChamber;
    bool emergencyButton;
    bool serviceSwitch;
    bool inertSwitch;
    bool serviceNetwork;
    bool monitor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StepManager.Instance.currentStepId == "3.1" && fineFilter)
        {
            StepManager.Instance.Process("3.1");
            fineFilter = false;
        }

        if (StepManager.Instance.currentStepId == "3.2" && preFrilter)
        {
            StepManager.Instance.Process("3.2");
            preFrilter = false;
        }

        if (StepManager.Instance.currentStepId == "3.3" && processChamber)
        {
            StepManager.Instance.Process("3.3");
            processChamber = false;
        }

        if (StepManager.Instance.currentStepId == "3.4" && emergencyButton)
        {
            StepManager.Instance.Process("3.4");
            emergencyButton = false;
        }

        if (StepManager.Instance.currentStepId == "3.5" && serviceSwitch)
        {
            StepManager.Instance.Process("3.5");
            serviceSwitch = false;
        }

        if (StepManager.Instance.currentStepId == "3.6" && inertSwitch)
        {
            StepManager.Instance.Process("3.6");
            inertSwitch = false;
        }

        if (StepManager.Instance.currentStepId == "3.7" && serviceNetwork)
        {
            StepManager.Instance.Process("3.7");
            serviceNetwork = false;
        }

        if (StepManager.Instance.currentStepId == "3.8" && monitor)
        {
            StepManager.Instance.Process("3.8");
            monitor = false;
        }
    }

    public void MachineOn()
    {
        machine = true;
    }

    public void FineFilterOn()
    {
        fineFilter = true;
    }

    public void PreFilterOn()
    {
        preFrilter = true;
    }

    public void ProcessChamberOn()
    {
        processChamber = true;
    }

    public void EmergencyButotnOn()
    {
        emergencyButton = true;
    }

    public void ServiceSwitchOn()
    {
        serviceSwitch = true;
    }

    public void InertSwitchOn()
    {
        inertSwitch = true;
    }

    public void ServiceNetworkOn()
    {
        serviceNetwork = true;
    }

    public void MonitorOn()
    {
        monitor = true;
    }

    public void OpenOutDoor()
    {
        if(StepManager.Instance.currentStepId == "3.10")
        {
            StepManager.Instance.Process("3.10");
        }
    }

    //bool machine;
    //bool fineFilter;
    //bool preFrilter;
    //bool processChamber;
    //bool emergencyButton;
    //bool serviceSwitch;
    //bool inertSwitch;
    //bool serviceNetwork;
    //bool monitor;
}
