using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewCounter : MonoBehaviour
{
    public int screwCount;
    public int currentLevelCount;

    public bool allScrewAreProcessed;
    public StepManager stepManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(screwCount == currentLevelCount)
        {
            if(!allScrewAreProcessed)
            {
                //multiple object is put in
                Debug.Log("iuaysgdyuasgd8yusa");
                stepManager.stepColliderController.ProcessNext();
                allScrewAreProcessed = true;
            }
            
        }
    }
}
