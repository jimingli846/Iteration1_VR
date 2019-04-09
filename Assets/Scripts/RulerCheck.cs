using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerCheck : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform bladeBottom, plateTop;

    [SerializeField] GameObject Quad;

    TextMesh txt;
    bool step613processed, p50, p55, p60;

    float sizeOfRuler;

    void Start()
    {
        txt = Quad.GetComponentInChildren<TextMesh>();
        sizeOfRuler = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {

        if(StepManager.Instance.currentStepId=="6.13" && !step613processed)
        {
            StepManager.Instance.Process("6.13");
            step613processed = true;
        }

        if (this.gameObject.name.StartsWith("500Micron"))
        {
            if(p50 && StepManager.Instance.currentStepId == "6.14")
            {
                StepManager.Instance.Process("6.14");
                p50 = false;
            }
        }

        else if (this.gameObject.name.StartsWith("600Micron"))
        {
            if (p60 && StepManager.Instance.currentStepId == "6.15")
            {
                StepManager.Instance.Process("6.15");
                p60 = false;
            }
        }

        else if (this.gameObject.name.StartsWith("550Micron"))
        {
            if (p55 && StepManager.Instance.currentStepId == "6.16")
            {
                StepManager.Instance.Process("6.16");
                StartCoroutine("Process617");
                p55 = false;
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.StartsWith("RulerTrigger"))
        {
            Quad.SetActive(true);
            /*if (bladeBottom.position.y - plateTop.position.y > sizeOfRuler)         //If distance between is more than ruler, then ok
            {                
                txt.text = "Distance between Blade \n and Plate is " + (bladeBottom.position.y - plateTop.position.y) * 1000 + " mm";
            }
            else
            {
                txt.text = "Ruler too thick, please use a different one";
            }
            */
           // txt.text = "Distance between Blade \n and Plate is " + (bladeBottom.position.y - plateTop.position.y) * 1000 + " mm";

            if (this.gameObject.name.StartsWith("500Micron"))
            {
                txt.text = "\n Too Big! Try .60mm!";
                p50 = true;
            }
            else if (this.gameObject.name.StartsWith("600Micron"))
            {
                txt.text = "\n Too Small! Try .55mm!";
                p60 = true;
            }
            else if (this.gameObject.name.StartsWith("550Micron"))
            {
                txt.text = "\n PERFECT!";
                p55 = true;
            }

            plateTop.transform.position = new Vector3(bladeBottom.transform.position.x, plateTop.transform.position.y, bladeBottom.transform.position.z);
        }
    }

    private IEnumerator Process617()
    {
        yield return new WaitForSeconds(1f);
        //StepManager.Instance.Process("6.17");
    }

    private void OnTriggerExit(Collider other)
    {
        Quad.SetActive(false);
    }
}
