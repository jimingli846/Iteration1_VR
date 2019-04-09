using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main1LevelManager : MonoBehaviour
{
    public GameObject[] modules = new GameObject[4];
    void Start()
    {
        
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (GameObject module in modules)
                module.SetActive(false);

            modules[0].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (GameObject module in modules)
                module.SetActive(false);

            modules[1].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (GameObject module in modules)
                module.SetActive(false);

            modules[2].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach (GameObject module in modules)
                module.SetActive(false);

            modules[3].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (GameObject module in modules)
                module.SetActive(false);

            modules[0].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (GameObject module in modules)
                module.SetActive(false);

            modules[1].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (GameObject module in modules)
                module.SetActive(false);

            modules[2].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main 1");
        }
    }
}
