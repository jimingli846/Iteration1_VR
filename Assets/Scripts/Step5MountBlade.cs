using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step5MountBlade : MonoBehaviour
{
    bool bladeHousingOn;
    bool steelOn;
    bool brushOn;
    bool ceramicOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StepManager.Instance.currentStepId == "5.1" && bladeHousingOn)
        {
            StepManager.Instance.Process("5.1");
            bladeHousingOn = false;
        }
        else if (StepManager.Instance.currentStepId == "5.2" && steelOn)
        {
            StepManager.Instance.Process("5.2");
            steelOn = false;
        }
        else if (StepManager.Instance.currentStepId == "5.3" && brushOn)
        {
            StepManager.Instance.Process("5.3");
            brushOn = false;
        }
        else if (StepManager.Instance.currentStepId == "5.4" && ceramicOn)
        {
            StepManager.Instance.Process("5.4");
            ceramicOn = false;
        }

       
    }

    public void BladeHousingOn()
    {
        bladeHousingOn = true;
    }

    public void SteelOn()
    {
        steelOn = true;
    }

    public void BrushOn()
    {
        brushOn = true;
    }

    public void CeramicOn()
    {
        ceramicOn = true;
    }
}
