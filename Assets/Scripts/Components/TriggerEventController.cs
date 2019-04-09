using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventController : MonoBehaviour
{
    public Transform DestinyPosition;
    // Start is called before the first frame update
    void Start()
    {
        DestinyPosition = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<GrabableObjectController>().isInPosition = true;
        other.GetComponent<GrabableObjectController>().destinyTransform = DestinyPosition;
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<GrabableObjectController>().isInPosition = false;
    }
}
