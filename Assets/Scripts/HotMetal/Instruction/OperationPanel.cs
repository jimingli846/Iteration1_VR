using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperationPanel : MonoBehaviour
{
    public Text txtOperation;
    public void updateOperation(OperationObject operation)
    {
        txtOperation.text = operation.Operation;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
