﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_UpdateNitroBar : MonoBehaviour {

    private Car carInstance;
    private RectTransform rectTransform;
    private Vector2 rectSize;
    private float originalHeight;
    private float auxCarNitro;
    // Use this for initialization
    void Start()
    {
        carInstance = Car.instance;
        auxCarNitro = carInstance.nitroAcumulation;
        rectTransform = GetComponent<RectTransform>();
        rectSize = rectTransform.sizeDelta;
        originalHeight = rectSize.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (auxCarNitro != carInstance.maxNitroAcumulation)
        {
            rectSize.y = (carInstance.nitroAcumulation * originalHeight) / carInstance.maxNitroAcumulation;
            rectTransform.sizeDelta = rectSize;
            auxCarNitro = carInstance.nitroAcumulation;
        }
    }
}