using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using cakeslice;

public class GlowEffect : MonoBehaviour {
    
	private GameObject glowObject;

    private Renderer glowRenderer;
    public Material glowMaterial;
    
    private Color yellowColor, blueColor, greenColor, currentColor;
    private Coroutine stopCoroutine;
    private Coroutine stopOutlineCoroutine;

    private OutlineEffect outlineEffect;
    private Outline outline;

    private int colorCounter = 1;

    private float tempIntensity = 0f;
    private float outlineIntensity = 0f;

    private float speed = 2f;

    private float t = 0f;
    private float t2 = 0f;

    private float startTime;
    private bool isGlow;

	void Awake()
	{
	}

    
    void Start () {

        glowObject = this.gameObject;

        glowRenderer = glowObject.GetComponent<Renderer>();
        glowMaterial = glowRenderer.material;

        outline = this.GetComponent<Outline>();
        outlineEffect = Camera.main.GetComponent<OutlineEffect>();

        blueColor = Color.blue;
        yellowColor = Color.yellow;
        greenColor = Color.green;
        currentColor = yellowColor;

        startTime = Time.time;
    }
	
	void Update () {


        //if (colorCounter == 3)
        //    colorCounter = 0;
        //else colorCounter++;

        // t2 = Mathf.Sin(Time.time - startTime) * 3;

        if (isGlow)
        {
            t = (((Mathf.Sin((Time.time - startTime)) + Mathf.Cos(2 * (Time.time - startTime)) / 2) + 0.3f) * speed);


            tempIntensity = Mathf.Lerp(0, 4, t);
            outlineIntensity = Mathf.Lerp(0, 1.5f, t);

            /*
            if (colorCounter == 0)        {tempIntensity = 0;}
            else if (colorCounter == 1) { currentColor = yellowColor; }
            else if (colorCounter == 2) { currentColor = blueColor; }
            else if (colorCounter == 3) { currentColor = greenColor; }
            */

            glowMaterial.SetColor("_EmissionColor", currentColor * tempIntensity);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            changeColor(greenColor);
        }

        //outlineEffect.lineThickness = outlineIntensity ;

    }

    public void glowGreen()
    {
        isGlow = false;
        changeColor(greenColor);
        glowMaterial.SetColor("_EmissionColor", currentColor);
        stopCoroutine = StartCoroutine(stopGlowingAfterOneSec());
    }

    public void glowYellow()
    {
        if (stopCoroutine != null) StopCoroutine(stopCoroutine);
        stopCoroutine = null;
        changeColor(yellowColor);
        this.enabled = true;
        isGlow = true;
    }

    public void changeColor(Color color)
    {
        currentColor = color;
    }

    public void outlineGlow()
    {
        if (outline == null) outline = this.gameObject.AddComponent<Outline>();
        if (stopOutlineCoroutine != null) StopCoroutine(stopOutlineCoroutine);
        stopOutlineCoroutine = null;
        outline.enabled = true;
        outline.color = 0;
    }

    public void outlineGreen()
    {
        outline.color = 1;
        stopOutlineCoroutine = StartCoroutine(stopOutlineAfterTwoSec());
    }

    public void stopOutline()
    {
        if (outline != null) outline.enabled = false;
    }

    IEnumerator stopOutlineAfterTwoSec()
    {
        yield return new WaitForSeconds(2f);
        stopOutline();
    }


    IEnumerator stopGlowingAfterOneSec()
    {
        yield return new WaitForSeconds(2f);
        glowMaterial.SetColor("_EmissionColor", currentColor * 0);
        this.enabled = false;
        stopCoroutine = null;
    }

    public void clear()
    {
        if (stopCoroutine != null) StopCoroutine(stopCoroutine);
        glowMaterial.SetColor("_EmissionColor", currentColor * 0);
        this.enabled = false;
        stopOutline();
        isGlow = false;
    }
}
