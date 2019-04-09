using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int levelIndex;
    public bool levelIsFinished;

    public LevelManager levelManager;

    public GameObject levelButton;

    private bool levelSwitched;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(levelIsFinished && !levelSwitched)
        {
            Debug.Log("level" + levelManager.currentLevel + "is finished");
            levelManager.LoadNextLevel();
            levelSwitched = true;
        }
    }
}
