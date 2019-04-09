using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionPanel : MonoBehaviour
{
    public Text txtOperation;
    public Text txtStep;
    public Transform operationPanel;
    public GameObject operationPrefab;
    public Button btnNext;
    public Image imgStep;

    public void updateStep(StepObject step)
    {
        txtOperation.text = step.Operation;
        if (step.TargetCount == -1)
        {
            txtStep.text = step.Step;
        } else
        {
            txtStep.text = step.Step + string.Format(" ({0} / {1})", step.CurrentCount, step.TargetCount);
        }
        if (step.Image != "" && step.Image != null)
        {
            imgStep.enabled = true;
            string url = "Images/" + step.Image;
            Texture2D tex = Resources.Load<Texture2D>(url);
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height),
                new Vector2());
            imgStep.sprite = sprite;
            imgStep.preserveAspect = true;
        } else
        {
            imgStep.enabled = false;
        }
        if (step.ButtonText != null && step.ButtonText != "")
        {
            btnNext.GetComponentInChildren<Text>().text = step.ButtonText;
        }
    }

    public void updateCount(StepObject step)
    {
        txtStep.text = step.Step + string.Format(" ({0} / {1})", step.CurrentCount, step.TargetCount);
    }

    public void updateOperations(List<OperationObject> operations)
    {
        int y = 0;
        foreach (OperationObject operationObject in operations)
        {
            GameObject operation = Instantiate(operationPrefab, operationPanel);
            operation.transform.localPosition = new Vector3(0, y, 0);
            operation.GetComponent<OperationPanel>().updateOperation(operationObject);
            y -= 10;
        }
    }

    public void UpdateState()
    {
        if (StepManager.Instance.currentState == StepManager.StepState.Completed)
        {
            btnNext.gameObject.SetActive(true);
        }
        else
        {
            btnNext.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        btnNext.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
