using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step5_10 : MonoBehaviour
{
    public GameObject[] triggers;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "5.10", stepStartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "5.10", stepEndHandler);
    }

    void stepStartHandler()
    {
        foreach (GameObject trigger in triggers)
        {
            trigger.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    void stepEndHandler()
    {
        foreach (GameObject trigger in triggers)
        {
            trigger.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
