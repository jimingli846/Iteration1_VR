using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StepObject
{
    public string Id;
    public string Step;
    public string Highlight;
    public string Outline;
    public string Operation;
    public string Image;
    public int CurrentCount = 0;
    public int TargetCount = -1;
    public int ShowNextButton = 1;
    public int AutoProceed = 0;
    public string ButtonText;
}
