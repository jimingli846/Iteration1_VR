using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAPI : MonoBehaviour {
	public Text stepIndicator;
    public GameObject btnStep1;
	public GameObject btnStep2;
    public GameObject btnStep3;

	public void Test() {
		NetworkManager.Instance.gradeSAI ("button1", "ButtonPressed", "click");
	}

	public void FinishStep0() {
        //NetworkManager.Instance.gradeSAI ("step", "Step0Finished", "-1");
        //StepManager.Instance.Process("step0");
	}

	public void FinishStep1() {
        //NetworkManager.Instance.gradeSAI ("step", "Step1Finished", "-1");
        //StepManager.Instance.Process("step1");
	}

    public void FinishStep2()
    {
        //NetworkManager.Instance.gradeSAI("step", "Step2Finished", "-1");
        //StepManager.Instance.Process("step2");
    }

	void Start() {
		NetworkManager.Instance.setStep += setStepHandler;
		btnStep2.SetActive (false);
        btnStep3.SetActive(false);

        StepManager.Instance.SetStep("step0");
    }

    void Step0EndHandler()
    {
        btnStep1.SetActive(false);
    }

    void Step3Handler()
    {
        setStepHandler("step3");
    }

    void Step2Handler()
    {
        setStepHandler("step2");
    }

    void Step1Handler()
    {
        Debug.Log("This is Step1");
        setStepHandler("step1");
    }

    void Step0Handler()
    {
        Debug.Log("This is Step0");
    }

    void setStepHandler(string step) {
		stepIndicator.text = "Step: " + step;
		if (step == "step1") {
			btnStep2.SetActive (true);
		} else if (step == "step2")
        {
            btnStep3.SetActive(true);
        }
	}
}
