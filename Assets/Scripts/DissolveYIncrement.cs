using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;

public class DissolveYIncrement : MonoBehaviour
{
    Material mat;
    public float speedOfSpark = 0.1f;
   // float val;

    public GameObject spark, recoater, plateHolderPivot, textBox;

    TextMesh txt;
    int numberOfLayersDone = 0;

    float originalX, originalZ;

    float deltaX, deltaZ, deltaY;

    float upperZLimit = 0.02f;
    float upperXLimit = 0.044f;

    bool goingUp = true;

    bool sparkleTime = true;

    float lerpConstant = 0;
    float lerpConstant2 = 0;

    float currentY;

    public float howLongDoYouWantTheExperienceToBe = 3;

    bool recoaterMovement = false;

    float recoaterMoveSpeed = 0.1f;

    public int howManyTimesDidYouDoIt = 0;

    bool isGoingLeft = true;

    bool processStarted = false;

    bool stopProcess = false;


    private float xmax = 0.2f;
    private float xmin = -0.1f;

    private void OnEnable()
    {
        textBox.SetActive(true);
        txt = textBox.GetComponentInChildren<TextMesh>();
        txt.text = "Build in Progress "+"\nLayers Done: ";


        mat = GetComponent<Renderer>().material;
        mat.SetFloat("_DissolveY", transform.position.y - 0.0001f);

        // val = mat.GetFloat("_DissolveY");

        spark.SetActive(true);

        originalX = spark.transform.localPosition.x;
        originalZ = spark.transform.localPosition.z;

        currentY = plateHolderPivot.transform.localPosition.y;

    }

    void Start()
    {
        Time.timeScale = 4f;
    }

    // Update is called once per frame
    void Update()
    {

        if (!stopProcess)
        {
            if (sparkleTime)
            {
                StartCoroutine("SparksEffect");
            }

            else if (recoaterMovement)
            {
                StartCoroutine("MoveRecoater");
            }
        }

        if (StepManager.Instance.currentStepId == "9.1")
        {
            if (!processStarted)
            {
                processStarted = true;
                sparkleTime = true;
                spark.SetActive(true);
                Time.timeScale = 4f;
            }

            if (howManyTimesDidYouDoIt >= 2 && processStarted)
            {
                StepManager.Instance.Process("9.1");
            }
        }

        else if (howManyTimesDidYouDoIt == 6 && StepManager.Instance.currentStepId == "10.1")
        {
            StepManager.Instance.Process("10.1");
        }

        else if (howManyTimesDidYouDoIt > 25 && StepManager.Instance.currentStepId == "10.2")
        {
            howManyTimesDidYouDoIt = 0;
            mat.SetFloat("_DissolveY", 1000f);
            StepManager.Instance.Process("10.2");
            stopProcess = true;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<PickUpRuler>().enabled = true;
            Time.timeScale = 1f;
            SoundManager.Instance.playHallelujah();
        }
        // else StartCoroutine("MoveRecoater");


        /*   if (Input.GetKey(KeyCode.M)){

               spark.SetActive(true);
               val += 0.00003f;
               mat.SetFloat("_DissolveY", val);

               spark.transform.Translate(0, 0.0012f * Time.deltaTime, 0);


           }

           else if (Input.GetKeyUp(KeyCode.M))
           {
               spark.SetActive(false);
           }
           else if (Input.GetKey(KeyCode.N))
           {
               val -= 0.00003f;
               mat.SetFloat("_DissolveY", val);
           }

       */
    }

    private IEnumerator SparksEffect()
    {

        
        deltaZ = spark.transform.localPosition.z - originalZ;
        deltaX = spark.transform.localPosition.x - originalX;

        lerpConstant = Mathf.Lerp(0, 1, deltaX);

        if (deltaZ >= upperZLimit)
        {
            deltaZ = 0;
            goingUp = false;
            spark.transform.Translate(speedOfSpark * Time.deltaTime, 0, 0);
        }

        else if (deltaZ <= 0)
        {
            deltaZ = 0;
            goingUp = true;
        }

        if (deltaX >= upperXLimit)
        {
            deltaX = 0;
            spark.transform.localPosition = new Vector3(originalX, spark.transform.localPosition.y, spark.transform.localPosition.z);
            sparkleTime = false;
            spark.SetActive(false);
            howManyTimesDidYouDoIt++;
            numberOfLayersDone += 60;
            txt.text = "Build in Progress " + "\nLayers Done: "+numberOfLayersDone;
            recoaterMovement = true;
          //  Debug.Log(howManyTimesDidYouDoIt + " many times");
        }

        if (goingUp)
            spark.transform.Translate(0, 0, speedOfSpark * Time.deltaTime * 3);
        else spark.transform.Translate(0, 0, -speedOfSpark * Time.deltaTime * 3);

        Mathf.Clamp(transform.localPosition.z, originalZ, originalZ + upperZLimit);

        lerpConstant2 = Mathf.Lerp(0, 0.0046f, deltaX);

        deltaY = plateHolderPivot.transform.localPosition.y - currentY;
  
        plateHolderPivot.transform.localPosition -= new Vector3(0, 0.00046f * Time.deltaTime * howLongDoYouWantTheExperienceToBe, 0);
        transform.localPosition -= new Vector3(0, 0.00046f * Time.deltaTime * howLongDoYouWantTheExperienceToBe, 0);

        yield return null;
    }

    private IEnumerator MoveRecoater()
    {

        if (isGoingLeft)
        {
            recoater.transform.Translate(Vector3.right * recoaterMoveSpeed * Time.deltaTime);

            if (recoater.transform.localPosition.x > xmax)
            {
                recoater.transform.localPosition = new Vector3(xmax, recoater.transform.localPosition.y, recoater.transform.localPosition.z);
                isGoingLeft = false;
            }
        }
        else if (!isGoingLeft)
        {
            recoater.transform.Translate(Vector3.left * recoaterMoveSpeed * Time.deltaTime);

            if (recoater.transform.localPosition.x < xmin)
            {
                recoater.transform.localPosition = new Vector3(xmin, recoater.transform.localPosition.y, recoater.transform.localPosition.z);
                recoaterMovement = false;
                sparkleTime = true;
                spark.SetActive(true);
                isGoingLeft = true;
            }
        }

        yield return null;
    }
}
