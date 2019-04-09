using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumKeyController : MonoBehaviour
{
    public string keyIndex;
    public KeyPanelInputController KIC;
    public GameObject confirmCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NumBackSpace()
    {
        Debug.Log("BACKSPACE" + KIC.currentInput);
        if(KIC.currentInput > 0)
        {
            if(KIC.lastInputIsDot)
            {
                KIC.inputText.text = KIC.inputText.text.Substring(0, KIC.inputText.text.Length -1);
            }
            else
            {
                Debug.Log(KIC.inputText.text);
                KIC.inputText.text = KIC.inputText.text.Substring(0, KIC.inputText.text.Length - 5);
                Debug.Log(KIC.inputText.text);
            }
            KIC.currentInput -= 1;
            if(KIC.currentInput == 3)
            {
                Debug.Log("Last Input Delete!");
                confirmCollider.GetComponent<Collider>().enabled = false;
                confirmCollider.GetComponent<Renderer>().material.color = Color.grey;
            }
        }
    }
    public void NumInput()
    {
        if(KIC.currentInput < 4)
        {
            KIC.inputText.text += keyIndex;
            KIC.currentInput += 1;
            
            KIC.lastInputIsDot = false;
            if (keyIndex == ".")
            {
                KIC.lastInputIsDot = true;
            }
            if (KIC.currentInput == 4)
            {
                confirmCollider.GetComponent<Collider>().enabled = true;
                confirmCollider.GetComponent<Renderer>().material.color = Color.white;
            }
        }
        
    }
}
