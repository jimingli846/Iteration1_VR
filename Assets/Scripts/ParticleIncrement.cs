using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleIncrement : MonoBehaviour
{
    
    public float multiplier = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleTrigger()
    {

        multiplier++;

    }

}
