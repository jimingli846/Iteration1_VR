using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManagerTest : MonoBehaviour
{
    public StepManager stepManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("123");
            stepManager.SetStep("6.4");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("234");
            stepManager.SetStep("5.7");
        }
    }
}
