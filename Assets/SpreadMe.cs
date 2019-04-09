using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadMe : MonoBehaviour
{

    private float speed = 0.1f;
    private bool spreadingNow;

    private float xmax = -0.95f;
    private GameObject recoater;

    private Vector3 recoaterHardCodedTransform = new Vector3(-0.1f, 0.125f, -0.0417f);

    private void OnEnable()
    {
    }

    void Start()
    {
        recoater.transform.localPosition = recoaterHardCodedTransform;
    }
    

    void Update()
    {
        if (spreadingNow && transform.localPosition.x >= xmax)
        {
            transform.localScale += new Vector3(speed * Time.deltaTime, 0, 0);
            transform.localPosition -= new Vector3(speed / 2 * Time.deltaTime, 0, 0);
        }

        float xval = transform.localPosition.x;
        Mathf.Clamp(xval, xmax, 10);
        transform.localPosition = new Vector3(xval, transform.localPosition.y, transform.localPosition.z);
    }

    public void SpreadMeNow(bool boolean)
    {
        spreadingNow = boolean;
    }
}
