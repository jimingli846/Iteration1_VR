using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabellingTag : MonoBehaviour
{

    public GameObject QuadLabel;
    public TextMesh txt;
    public Transform VRCamera;

    void Start()
    {
        QuadLabel.transform.LookAt(VRCamera);
    }

    // Update is called once per frame
    void Update()
    {
        QuadLabel.transform.LookAt(VRCamera);
    }
    
    public void showTagForObject(string str)
    {
        txt.text = str;
    }

    public void attachToObject(Transform _transform)
    {
        QuadLabel.transform.position = new Vector3(_transform.position.x, _transform.position.y+0.05f, _transform.position.z);
    }
    
}
