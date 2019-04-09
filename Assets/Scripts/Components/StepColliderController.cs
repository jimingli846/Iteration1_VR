using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepColliderController : MonoBehaviour
{
    public int currentStep;

    public Dictionary<int, GameObject[]> targetCollider = new Dictionary<int, GameObject[]>();

    public Dictionary<int, string> stepDic = new Dictionary<int, string>();

    public List<Collider[]> triggerSum = new List<Collider[]>();

    //colliders are pickable
    //triggers are enabled when level start


    public GameObject[] colliders55;
    public GameObject[] colliders56;
    public GameObject[] colliders57;
    public GameObject[] colliders58;
    public GameObject[] colliders59;
    public GameObject[] colliders510;
    public GameObject[] colliders61;
    public GameObject[] colliders62;
    public GameObject[] colliders63;
    public GameObject[] colliders64;
    public GameObject[] colliders65;
    public GameObject[] colliders66;
    public GameObject[] colliders67;
    public GameObject[] colliders68;
    public GameObject[] colliders69;
    public GameObject[] colliders610;
    public GameObject[] colliders611;
    public GameObject[] colliders612;

    public Collider[] triggers56;
    public Collider[] triggers58;
    public Collider[] triggers510;
    public Collider[] triggers62;
    public Collider[] triggers64;
    public Collider[] triggers68;
    public Collider[] triggers613;
    

    
    

    // Start is called before the first frame update
    void Awake()
    {
        stepDic.Add(55, "5.5");
        stepDic.Add(56, "5.6");
        stepDic.Add(57, "5.7");
        stepDic.Add(58, "5.8");
        stepDic.Add(59, "5.9");
        stepDic.Add(510, "5.10");
        stepDic.Add(61, "6.1");
        stepDic.Add(62, "6.2");
        stepDic.Add(63, "6.3");
        stepDic.Add(64, "6.4");
        stepDic.Add(65, "6.5");
        stepDic.Add(66, "6.6");
        stepDic.Add(67, "6.7");
        stepDic.Add(68, "6.8");
        stepDic.Add(69, "6.9");
        stepDic.Add(610, "6.10");
        stepDic.Add(611, "6.11");
        stepDic.Add(612, "6.12");
        stepDic.Add(613, "6.13");
        stepDic.Add(614, "6.14");
        stepDic.Add(615, "6.15");
        stepDic.Add(616, "6.16");

        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "1.1", step11StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "1.1", step11EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "5.5", step55StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "5.5", step55EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "5.6", step56StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "5.6", step56EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "5.7", step57StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "5.7", step57EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "5.8", step58StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "5.8", step58EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "5.9", step59StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "5.9", step59EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "5.10", step510StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "5.10", step510EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "6.1", step61StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "6.1", step61EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "6.2", step62StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "6.2", step62EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "6.3", step63StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "6.3", step63EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "6.4", step64StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "6.4", step64EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "6.5", step65StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "6.5", step65EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "6.6", step66StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "6.6", step66EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "6.7", step67StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "6.7", step67EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "6.8", step68StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "6.8", step68EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "6.9", step69StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "6.9", step69EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "6.10", step610StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "6.10", step610EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "6.11", step611StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "6.11", step611EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "6.12", step612StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "6.12", step612EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "6.13", step613StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "6.13", step613EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "6.14", step614StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "6.14", step614EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "6.15", step615StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "6.15", step615EndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_START + "6.16", step616StartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_EACH_STEP_END + "6.16", step616EndHandler);


        targetCollider.Add(55, colliders55);
        targetCollider.Add(56, colliders56);
        targetCollider.Add(57, colliders57);
        targetCollider.Add(58, colliders58);
        targetCollider.Add(59, colliders59);
        targetCollider.Add(510, colliders510);
        targetCollider.Add(61, colliders61);
        targetCollider.Add(62, colliders62);
        targetCollider.Add(63, colliders63);
        targetCollider.Add(64, colliders64);
        targetCollider.Add(65, colliders65);
        targetCollider.Add(66, colliders66);
        targetCollider.Add(67, colliders67);
        targetCollider.Add(68, colliders68);
        targetCollider.Add(69, colliders69);
        targetCollider.Add(610, colliders610);
        targetCollider.Add(611, colliders611);
        targetCollider.Add(612, colliders612);


        triggerSum.Add(triggers56);
        triggerSum.Add(triggers58);
        triggerSum.Add(triggers510);
        triggerSum.Add(triggers62);
        triggerSum.Add(triggers64);
        triggerSum.Add(triggers68);
        triggerSum.Add(triggers613);


        foreach (Collider[] coll in triggerSum)
        {
            foreach(Collider col in coll)
            {
                col.enabled = false;
            }
        }


        currentStep = 55;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void step11StartHandler()
    {
        currentStep = 11;
        Debug.Log("1.1 start");
    }

    void step11EndHandler()
    {
        Debug.Log("1.1 ends");
    }

    void step55StartHandler()
    {
        currentStep = 55;
        Debug.Log("5.5 start");
    }

    void step55EndHandler()
    {
        Debug.Log("5.5 ends");
    }

    void step56StartHandler()
    {
        currentStep = 56;
        Debug.Log("5.6 start");
        TriggersEnable(triggers56);
    }

    void step56EndHandler()
    {
        Debug.Log("5.6 ends");
        TriggersDisable(triggers56);
    }

    void step57StartHandler()
    {
        currentStep = 57;
        Debug.Log("5.7 start");
    }

    void step57EndHandler()
    {
        Debug.Log("5.7 ends");
    }

    void step58StartHandler()
    {
        currentStep = 58;
        Debug.Log("5.8 start");
        TriggersEnable(triggers58);
    }

    void step58EndHandler()
    {
        Debug.Log("5.8 ends");
        TriggersDisable(triggers58);
    }

    void step59StartHandler()
    {
        currentStep = 59;
        Debug.Log("5.9 start");
        TriggersEnable(triggers58);
    }

    void step59EndHandler()
    {
        Debug.Log("5.9 ends");
    }

    void step510StartHandler()
    {
        currentStep = 510;
        Debug.Log("5.10 start");
        TriggersEnable(triggers510);
    }

    void step510EndHandler()
    {
        Debug.Log("5.10 ends");
        TriggersDisable(triggers510);
    }

    void step61StartHandler()
    {
        currentStep = 61;
        Debug.Log("6.1 start");
    }

    void step61EndHandler()
    {
        Debug.Log("6.1 ends");
        colliders61[0].gameObject.GetComponent<InteractableTest>().enabled = false;
    }

    void step62StartHandler()
    {
        currentStep = 62;
        Debug.Log("6.2 start");
        TriggersEnable(triggers62);
    }

    void step62EndHandler()
    {
        Debug.Log("6.2 ends");
        TriggersDisable(triggers62);
    }

    void step63StartHandler()
    {
        currentStep = 63;
        Debug.Log("6.3 start");
    }

    void step63EndHandler()
    {
        Debug.Log("6.3 ends");
    }


    void step64StartHandler()
    {
        currentStep = 64;
        Debug.Log("6.4 start");
        TriggersEnable(triggers64);
    }

    void step64EndHandler()
    {
        Debug.Log("6.4 ends");
        TriggersDisable(triggers64);
    }

    void step65StartHandler()
    {
        currentStep = 65;
        Debug.Log("6.5 start");
    }

    void step65EndHandler()
    {
        Debug.Log("6.5 ends");
    }

    void step66StartHandler()           //Enable buttons for moving recoater left/right
    {
        currentStep = 66;
        Debug.Log("6.6 start");
    }

    void step66EndHandler()             //Dont do anything
    {
        Debug.Log("6.6 ends");
    }

    void step67StartHandler()           //Pick up the indicator. Call when indicator is picked up/held  //Enable the collider of the Indicator
    {
        currentStep = 67;
        Debug.Log("6.7 start");

    }

    void step67EndHandler()             //Don't do anything
    {
        Debug.Log("6.7 ends");
    }


    void step68StartHandler()           //Enable the trigger for the indicator place -- Not implemented yet
    {
        currentStep = 68;
        Debug.Log("6.8 start");
        TriggersEnable(triggers68);
    }

    void step68EndHandler()             //Disable the trigger for the indicator place -- Not implemented yet
    {
        Debug.Log("6.8 ends");
        TriggersDisable(triggers68);
    }

    void step69StartHandler()           //Don't do anything
    {
        currentStep = 69;
        Debug.Log("6.9 start");
    }

    void step69EndHandler()             //Don't do anything
    {
        Debug.Log("6.9 ends");
    }

    void step610StartHandler()           //Enable level rocker switch
    {
        currentStep = 610;
        Debug.Log("6.10 start");
    }

    void step610EndHandler()             //Don't do anything
    {
        Debug.Log("6.10 ends");
    }

    void step611StartHandler()           //Don't do anything
    {
        currentStep = 611;
        Debug.Log("6.11 start");
    }

    void step611EndHandler()             //Don't do anything
    {
        Debug.Log("6.11 ends");
    }

    void step612StartHandler()           //Pick up the indicator. Call when indicator is picked up/held  //Enable the collider of the Indicator
    {
        currentStep = 612;
        Debug.Log("6.12 start");
    }

    void step612EndHandler()             //Disable level rocker, indicator, recoater movement
    {
        Debug.Log("6.12 ends");
    }
    void step613StartHandler()           //Pick up the indicator. Call when indicator is picked up/held  //Enable the collider of the Indicator
    {
        TriggersEnable(triggers613);
        currentStep = 613;
        Debug.Log("6.13 start");
    }

    //Ignore comments from down here

    void step613EndHandler()             //Disable level rocker, indicator, recoater movement
    {
        Debug.Log("6.13 ends");
    }
    void step614StartHandler()           //Pick up the indicator. Call when indicator is picked up/held  //Enable the collider of the Indicator
    {
        currentStep = 614;
        Debug.Log("6.14 start");
    }

    void step614EndHandler()             //Disable level rocker, indicator, recoater movement
    {
        Debug.Log("6.14 ends");
    }
    void step615StartHandler()           //Pick up the indicator. Call when indicator is picked up/held  //Enable the collider of the Indicator
    {
        currentStep = 615;
        Debug.Log("6.15 start");
    }

    void step615EndHandler()             //Disable level rocker, indicator, recoater movement
    {
        Debug.Log("6.15 ends");
    }
    void step616StartHandler()           //Pick up the indicator. Call when indicator is picked up/held  //Enable the collider of the Indicator
    {
        currentStep = 616;
        Debug.Log("6.12 start");
    }

    void step616EndHandler()             //Disable level rocker, indicator, recoater movement
    {
        Debug.Log("6.16 ends");
        TriggersDisable(triggers613);
    }

    void TriggersEnable(Collider[] col)
    {
        foreach(Collider collider in col)
        {
            collider.enabled = true;
        }
    }

    void TriggersDisable(Collider[] col)
    {
        foreach (Collider collider in col)
        {
            collider.enabled = false;
        }
    }

    //check pick up objects
    public bool CheckTarget(GameObject gameObject)
    {
        foreach(GameObject game in targetCollider[currentStep])
        {
            if(game == gameObject)
            {
                return true;
            }
        }
        return false;
    }

    public void ProcessNext()
    {
        Debug.Log(currentStep + "is Finished");
        StepManager.Instance.Process(stepDic[currentStep]);
    }
}
