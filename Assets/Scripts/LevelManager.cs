using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Level[] levels;
    public Text currentLevelText;
    public int currentLevel;

    

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 0;
        ColliderEnable(0);
    }

    // Update is called once per frame
    void Update()
    {
        currentLevelText.text = "Current Level is:" + currentLevel;

    }

    public void LoadNextLevel()
    {
        ColliderDisable(currentLevel);
        currentLevel += 1;
        ColliderEnable(currentLevel);
    }

    public void ColliderEnable(int currentlevel)
    {
        levels[currentLevel].levelButton.SetActive(true);
    }

    public void ColliderDisable(int currentlevel)
    {
        levels[currentLevel].levelButton.SetActive(false);
    }

}
