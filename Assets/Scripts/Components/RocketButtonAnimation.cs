using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketButtonAnimation : MonoBehaviour
{
    public GameObject verticalRocket;
    public GameObject horizontalRocket;

    private int verticalId;
    private int horizontalId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (horizontalId){
            case 1:
                horizontalRocket.transform.localRotation = Quaternion.Euler(new Vector3(10, horizontalRocket.transform.rotation.y, horizontalRocket.transform.rotation.z));
                break;
            case 0:
                horizontalRocket.transform.localRotation = Quaternion.Euler(new Vector3(0, horizontalRocket.transform.rotation.y, horizontalRocket.transform.rotation.z));
                break;
            case -1:
                horizontalRocket.transform.localRotation = Quaternion.Euler(new Vector3(-10, horizontalRocket.transform.rotation.y, horizontalRocket.transform.rotation.z));
                break;
        }
        switch (verticalId)
        {
            case 1:
                verticalRocket.transform.localRotation = Quaternion.Euler(new Vector3(-10, verticalRocket.transform.rotation.y, verticalRocket.transform.rotation.z));
                break;
            case 0:
                verticalRocket.transform.localRotation = Quaternion.Euler(new Vector3(0, verticalRocket.transform.rotation.y, verticalRocket.transform.rotation.z));
                break;
            case -1:
                verticalRocket.transform.localRotation = Quaternion.Euler(new Vector3(10, verticalRocket.transform.rotation.y, verticalRocket.transform.rotation.z));
                break;
        }
        //verticalRocket.transform.localRotation = Quaternion.Euler(new Vector3(10, verticalRocket.transform.rotation.y, verticalRocket.transform.rotation.z));
    }

    

    public void SetHorizontal(int a)
    {
        horizontalId = a;
    }
    public void SetVertical(int a)
    {
        verticalId = a;
    }
}
