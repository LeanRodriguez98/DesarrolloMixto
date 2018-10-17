﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{


    public GameObject PausePanel;
    [HideInInspector]public Player playerInstance;

    private Vector3 turnRotation;
    private ButtonsManager instance;


    public Sprite volumeOn;
    public Sprite volumeOff;
    public Button volumeButon;
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
    private void Start()
    {
        if (Player.instance != null)
        {
            playerInstance = Player.instance;
            turnRotation = playerInstance.transform.eulerAngles;
            turnRotation.y -= 180;
        }

    }

    public void Pause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            PausePanel.SetActive(false);
        }
        
    }

    public void LoadScene(string name)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Test()
    {
        Debug.Log("TEST");
    }


    public void TurnOff(GameObject go)
    {
        go.SetActive(false);
    }

    public void TurnOn(GameObject go)
    {
        go.SetActive(true);
    }

    private void FixTurnAngle()
    {
        if (turnRotation.y <= -360)
        {
            turnRotation.y += 360;
        }
        if (turnRotation.y >= 360)
        {
            turnRotation.y -= 360;
        }
    }

    public void ChangeVolume()
    {
        if (AudioListener.volume > 0)
        {
            AudioListener.volume = 0;
            volumeButon.image.sprite = volumeOff;
        }
        else
        {
            AudioListener.volume = 1;
            volumeButon.image.sprite = volumeOn;
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    

  
}
