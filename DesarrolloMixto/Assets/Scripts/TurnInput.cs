﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnInput : MonoBehaviour {

    float initialX, finalX = 0;
    #region Singleton
    public static TurnInput instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
    #endregion
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            initialX = Input.mousePosition.x;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            finalX = Input.mousePosition.x;
            TurnLeft();
            TurnRight();
            initialX = finalX = 0;
        }  
    }

    public bool TurnLeft()
    {
        if (initialX > finalX)        
            return true;        
        return false;
    }

    public bool TurnRight()
    {
        if (initialX < finalX)
            return true;        
        return false;
    }

  
}
