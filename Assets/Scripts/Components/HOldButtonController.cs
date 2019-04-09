using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldButtonController : MonoBehaviour
{
    public bool buttonIsClicked;
    public int buttonIndex;

    public float verticalSpeed = 0.2f;

    public GameObject plane;
    public GameObject basePlane;
    public GameObject screw;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonAction()
    {
        switch (buttonIndex)
        {
            case 1:
                plane.transform.Translate(Vector3.up * Time.deltaTime * verticalSpeed);
                basePlane.transform.Translate(Vector3.up * Time.deltaTime * verticalSpeed);
                screw.transform.Translate(Vector3.up * Time.deltaTime * verticalSpeed);
                Debug.Log("Button Up");
                break;

            case 2:
                plane.transform.Translate(Vector3.down * Time.deltaTime * verticalSpeed);
                basePlane.transform.Translate(Vector3.down * Time.deltaTime * verticalSpeed);
                screw.transform.Translate(Vector3.down * Time.deltaTime * verticalSpeed);
                Debug.Log("Button Down");
                break;
        }

    }
}
