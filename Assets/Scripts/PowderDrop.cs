using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderDrop : MonoBehaviour
{
    // Start is called before the first frame update

    private float originalAngle, deltaAngle;

    [SerializeField] private GameObject powderParticleFx, fakePowder;

    private float speedScale;
    private float scaleOfPowder;

    ParticleSystem powderParticle;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    ParticleIncrement pi;


    void Start()
    {
        pi = powderParticleFx.GetComponent<ParticleIncrement>();
        powderParticle = powderParticleFx.GetComponent<ParticleSystem>();
        originalAngle = transform.rotation.eulerAngles.x;

        

    }



    // Update is called once per frame
    void Update()
    {
        deltaAngle = Mathf.Abs(transform.rotation.eulerAngles.x - originalAngle);

        if (deltaAngle > 90)
        {
            fakePowder.GetComponent<MeshRenderer>().enabled = true;
            powderParticle.Play();
        }

        else powderParticle.Stop();

        if(fakePowder.transform.localScale.y < 1)
        {
            fakePowder.transform.localScale = new Vector3(fakePowder.transform.localScale.x, fakePowder.transform.localScale.y + (pi.multiplier/1000) * Time.deltaTime, fakePowder.transform.localScale.z);
        }

        Mathf.Clamp(fakePowder.transform.localScale.y, 0, 1);

        if (StepManager.Instance.currentStepId == "7.2")
        {
            if (fakePowder.transform.localScale.y >= 1)
                StepManager.Instance.Process("7.2");
            else StepManager.Instance.SetIncomplete("7.2");
        }
    }
}
