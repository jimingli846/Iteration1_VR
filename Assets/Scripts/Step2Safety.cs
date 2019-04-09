using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step2Safety : MonoBehaviour
{
    // Start is called before the first frame update

    bool fireExt, wetSep, lowOxy, emeStop, inertGas;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StepManager.Instance.currentStepId == "2.1" && fireExt)     //Gloves
        {
            StepManager.Instance.Process("2.1");
            fireExt = false;
        }
        else if (StepManager.Instance.currentStepId == "2.2" && wetSep)     //Gloves
        {
            StepManager.Instance.Process("2.2");
            wetSep = false;
        }
        
        else if (StepManager.Instance.currentStepId == "2.3" && lowOxy)     //Gloves
        {
            StepManager.Instance.Process("2.3");
            lowOxy = false;
        }
        else if (StepManager.Instance.currentStepId == "2.4" && emeStop)     //Gloves
        {
            StepManager.Instance.Process("2.4");
            emeStop = false;
        }
        else if (StepManager.Instance.currentStepId == "2.5" && inertGas)     //Gloves
        {
            StepManager.Instance.Process("2.5");
            inertGas = false;
        }
    }

    public void FireExt()
    {
        fireExt = true;
    }
    public void WetSep()
    {
        wetSep = true;
    }
    public void LowOxy()
    {
        lowOxy = true;
    }
    public void EmeStop()
    {
        emeStop = true;
    }
    public void InertGas()
    {
        inertGas = true;
    }
}
