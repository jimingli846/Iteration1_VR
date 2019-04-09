using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewSpawn : MonoBehaviour
{

    public GameObject screwPrefab;
    private GameObject instantiatedObj;

    ScrewIt si;
    // Start is called before the first frame update
    void Start()
    {

        instantiatedObj = Instantiate(screwPrefab);
        instantiatedObj.GetComponent<ScrewIt>().hasCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
