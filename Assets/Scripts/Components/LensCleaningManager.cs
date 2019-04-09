using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensCleaningManager : MonoBehaviour
{
    public GameObject[] lensColliderA;
    public GameObject arrowA;
    public int Anum;

    public GameObject[] lensColliderB;
    public GameObject arrowB;
    public int Bnum;

    public GameObject[] lensColliderC;
    public GameObject arrowC;
    public int Cnum;

    public Step7 step7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void LineAEnable()
    {
        foreach(GameObject obj in lensColliderA)
        {
            obj.SetActive(true);
        }
        arrowA.SetActive(true);
    }

    public void LineBEnable()
    {
        foreach (GameObject obj in lensColliderB)
        {
            obj.SetActive(true);
        }
        arrowB.SetActive(true);
        arrowA.SetActive(false);
    }

    public void LineCEnable()
    {
        foreach (GameObject obj in lensColliderC)
        {
            obj.SetActive(true);
        }
        arrowC.SetActive(true);
        arrowB.SetActive(false);
    }
}
