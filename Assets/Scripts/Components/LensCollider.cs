using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensCollider : MonoBehaviour
{
    public LensCleaningManager lensCleaningManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cleaner")
        {
            this.gameObject.SetActive(false);
            if (this.gameObject.tag == "LineA")
            {
                lensCleaningManager.Anum += 1;
                if(lensCleaningManager.Anum == 6)
                {
                    lensCleaningManager.LineBEnable();
                }
            }
            if (this.gameObject.tag == "LineB")
            {
                lensCleaningManager.Bnum += 1;
                if (lensCleaningManager.Bnum == 6)
                {
                    lensCleaningManager.LineCEnable();
                }
            }
            if (this.gameObject.tag == "LineC")
            {
                lensCleaningManager.Cnum += 1;
                if (lensCleaningManager.Cnum == 6)
                {
                    lensCleaningManager.arrowC.SetActive(false);
                    lensCleaningManager.step7.ChangeMaskTarget();
                    StepManager.Instance.Process("7.8");
                }
            }
        }
    }
    
}
