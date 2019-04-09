using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{


    void Start()
    {
        
    }
    

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided with "+collision.gameObject.name);
        //Physics.IgnoreCollision(collision.transform.parent.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
    }
}
