using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager Instance = null;

    AudioSource audioSource;

    [SerializeField] AudioClip hoverClip, hideClip, completeClip, halleClip;

    private bool hoveringTablet = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void playHover()
    {
        if(!hoveringTablet)
            playSound(hoverClip);
    }

    public void playHideShow()
    {
        playSound(hideClip);
    }

    public void playCompleteStep()
    {
        playSound(completeClip);
    }

    public void playHallelujah()
    {
        playSound(halleClip);
    }

    private void playSound(AudioClip clip)
    {
        if (clip != null)
            audioSource.clip = clip;
        else Debug.Log("Cant play sound");

        
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    public void HoveringTablet ( bool boolean)
    {
        hoveringTablet = boolean;
    }

}
