using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class InstructionModel : Singleton<InstructionModel>
{
    public TextAsset textAsset;

    [Serializable]
    public class OperationsObject
    {
        public List<OperationObject> Operations;
    }

    private string jsonData;
    private OperationsObject operations;
    // Start is called before the first frame update

    public void init()
    {
        //StreamReader reader = new StreamReader("Assets/Assets/Resources/Configs/StepConfig.json");
        //jsonData = reader.ReadToEnd();
        jsonData = textAsset.text;

        operations = JsonUtility.FromJson<OperationsObject>(jsonData);
        foreach (OperationObject operation in operations.Operations)
        {
            foreach (StepObject step in operation.Steps)
            {
                step.Operation = operation.Operation;
            }
        }
    }

    public List<OperationObject> GetOperations()
    {
        return operations.Operations;
    }

    public StepObject GetStep(string stepId)
    {
        foreach (OperationObject operation in operations.Operations)
        {
            foreach (StepObject step in operation.Steps)
            {
                if (step.Id == stepId) return step;
            }
        }
        return null;
    }

    public StepObject GetNextStep(string stepId)
    {
        for (int i = 0; i < operations.Operations.Count; i++)
        {
            OperationObject operation = operations.Operations[i];
            for (int j = 0; j < operation.Steps.Count; j++)
            {
                StepObject step = operation.Steps[j];
                if (step.Id == stepId)
                {
                    if (j != operation.Steps.Count - 1)
                    {
                        return operation.Steps[j + 1];
                    }
                    else if (i != operations.Operations.Count - 1)
                    {
                        return operations.Operations[i + 1].Steps[0];
                    }
                }
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
