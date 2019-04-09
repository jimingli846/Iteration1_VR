using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltIt : MonoBehaviour
{

    public GameObject screwPrefab;
    private ScrewIt screwIt;

    [SerializeField] GameObject screwRot;

    private Vector3 screwRotEuler;
    // Start is called before the first frame update
    void Start()
    {
        screwRotEuler = screwRot.gameObject.transform.rotation.eulerAngles;
        screwIt = screwPrefab.GetComponent<ScrewIt>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("ScrewBottom"))
        {
            screwIt.hasCollided = true;
            Quaternion newRot = Quaternion.Euler(screwRotEuler);
            screwIt.gameObject.transform.rotation = newRot;
        }

        else if (other.gameObject.name.StartsWith("ScrewTop"))
            screwIt.hasCollided = false;
        
    }

   


}
