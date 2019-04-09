using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightView : MonoBehaviour
{
    private string[] currentHighlights;
    private string[] currentOutlines;
    private bool canGlow = true;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.AddEventHandler(EventManager.EVENT_STEP_START, StepStartHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_STEP_PROCESS, StepProcessHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_STEP_END, StepEndHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_STEP_INCOMPLETE, StepIncompleteHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_STOP_GLOW, StopGlowHandler);
        EventManager.Instance.AddEventHandler(EventManager.EVENT_START_GLOW, StartGlowHandler);
    }

    private void StepStartHandler()
    {
        if(canGlow)
            StartGlow();
    }

    private void StepIncompleteHandler()
    {
        StartGlow();
    }

    private void StartGlowHandler()
    {
        Debug.Log("StartGlowHandler");
        canGlow = true;
        StartGlow();

    }

    private void StartGlow()
    {
        StepObject stepObject = StepManager.Instance.currentStepObject;
        if (stepObject.Highlight != null)
        {
            currentHighlights = stepObject.Highlight.Split(',');
            foreach (string obj in currentHighlights)
            {
                GameObject gameObj = GameObject.Find(obj);
                if (gameObj.GetComponent<GlowEffect>() == null)
                {
                    gameObj.AddComponent<GlowEffect>();
                }
                else
                {
                    gameObj.GetComponent<GlowEffect>().enabled = true;
                }
                gameObj.GetComponent<GlowEffect>().glowYellow();
            }
        }
        if (stepObject.Outline != null)
        {
            currentOutlines = stepObject.Outline.Split(',');
            foreach (string obj in currentOutlines)
            {
                GameObject gameObj = GameObject.Find(obj);
                if (gameObj.GetComponent<GlowEffect>() == null)
                {
                    gameObj.AddComponent<GlowEffect>();
                }
                else
                {
                    gameObj.GetComponent<GlowEffect>().enabled = true;
                }
                gameObj.GetComponent<GlowEffect>().outlineGlow();
            }
        }
    }

    private void StepProcessHandler()
    {
        if (currentHighlights != null)
        {
            foreach (string obj in currentHighlights)
            {
                GameObject gameObj = GameObject.Find(obj);
                if (gameObj.GetComponent<GlowEffect>() != null)
                {
                    gameObj.GetComponent<GlowEffect>().glowGreen();
                }
            }
        }
        if (currentOutlines != null)
        {
            foreach (string obj in currentOutlines)
            {
                GameObject gameObj = GameObject.Find(obj);
                if (gameObj.GetComponent<GlowEffect>() != null)
                {
                    gameObj.GetComponent<GlowEffect>().outlineGreen();
                }
            }
        }
    }

    private void StepEndHandler()
    {
        if (currentHighlights != null)
        {
            foreach (string obj in currentHighlights)
            {
                GameObject gameObj = GameObject.Find(obj);
                if (gameObj.GetComponent<GlowEffect>() != null)
                {
                    gameObj.GetComponent<GlowEffect>().clear();
                }
            }
        }
    }

    private void StopGlowHandler()
    {
        Debug.Log("StopGlowHandler");
        if (currentHighlights != null)
        {
            foreach (string obj in currentHighlights)
            {
                GameObject gameObj = GameObject.Find(obj);
                if (gameObj.GetComponent<GlowEffect>() != null)
                {
                    gameObj.GetComponent<GlowEffect>().clear();
                }
            }
        }

        canGlow = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
