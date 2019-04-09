using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPanelInputController : MonoBehaviour
{
    public Text inputText;
    public int currentInput = 0;
    public GameObject plateHolderPivot;
    public bool lastInputIsDot;
    bool entered = true;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<OutlineController>().isConfirm = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputCheck() {
        
        if (inputText.text.Equals("  0  .  5    5  "))
        {
            Debug.Log("Correct Input");
            if(StepManager.Instance.currentStepId == "6.17")
            {
                StepManager.Instance.Process("6.17");
            }
            else
            {
                inputText.text = "";
                currentInput = 0;
            }
        }
        else
        {
            currentInput = 0;
            inputText.text = "";
        }
        this.GetComponent<Collider>().enabled = false;
        this.GetComponent<Renderer>().material.color = Color.grey;



    }

}
