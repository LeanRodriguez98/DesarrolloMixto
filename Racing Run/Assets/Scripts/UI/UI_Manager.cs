﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    private Car carInstance;
    private LevelManager levelManagerInstance;
    private int meters;
    private int playerLife;
    private int life;
    private int coins;
    public static UI_Manager instance;
    [HideInInspector] public int playerScore;
    [HideInInspector] public int playerConis;


    [Header("Texts")]
    [Space(10)]
    public Text metersText;
    public Text coinsText;
    [Header("Panels")]
    [Space(10)]
    public GameObject gameOverPanel;
    public GameObject inGamePanel;
    [Header("Buttons")]
    [Space(10)]
    public GameObject pauseButton;
    public GameObject nitroButton;
    private void Awake()
    {
        instance = this;
    }

    void Start () {
        carInstance = Car.instance;
        levelManagerInstance = LevelManager.instance;
        playerScore = meters = playerLife = life = playerConis = coins = 0;
    }

    void Update () {
        if (carInstance.gameObject.activeSelf)
        {



            if (levelManagerInstance != null)
                playerScore = (int)carInstance.metersTraveled;
            if (carInstance != null)
            {
                playerLife = carInstance.life;
                playerConis = carInstance.nuts;
            }

            if (playerScore != meters)
            {
                meters = playerScore;
                metersText.text = " " + meters.ToString() + " Mts";
            }

            if (playerLife != life)
            {
                life = playerLife;
            }

            if (playerConis != coins)
            {
                coins = playerConis;
                coinsText.text = coins.ToString();
            }
        }
        else
        {
            gameOverPanel.SetActive(true);
            inGamePanel.SetActive(false);
            pauseButton.SetActive(false);
            nitroButton.SetActive(false);
        }
    }
}
