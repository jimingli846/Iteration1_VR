using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelManager : MonoBehaviour
{
    public int currentLevelIndex;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        switch(currentLevelIndex)
        {
            case 1:
                Application.LoadLevel("MountBlade");
                break;
            case 2:
                Application.LoadLevel("Main 1");
                break;
            
        }
    }
}
