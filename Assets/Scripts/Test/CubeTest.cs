using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeTest : MonoBehaviour
{
    public Transform cube;
    public float angleY;
    public float angleZ;
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log(Mathf.Atan(1) * 180 / Mathf.PI);
        Debug.Log(Mathf.Atan(Mathf.Sqrt(3)) * 180 / Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {

        angleY = Mathf.Atan((cube.position.x - this.transform.position.x) / (cube.position.z - this.transform.position.z));
        
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, angleY * 180 / Mathf.PI, this.transform.rotation.z);

    }
}
