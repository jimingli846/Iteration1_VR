﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Clickable.OnMouseDown");
        //InstructionModel.Instance.interactObject = this.gameObject;
        //EventManager.Instance.SendEvent(EventManager.EVENT_CLICK_ITEM);
        this.gameObject.SetActive(false);
    }
}
