using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableCleaningItem : MonoBehaviour
{
    public Vector3 origPos;
    public Quaternion origRot;
    
    public LensCleaningManager lensCleaningManager;
    // Start is called before the first frame update
    void Start()
    {
        origPos = this.transform.localPosition;
        origRot = this.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToCorrectPosition()
    {

        this.transform.localPosition = origPos;
        this.transform.localRotation = origRot;

    }
}
