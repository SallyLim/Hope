﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class goNextScene : MonoBehaviour
{
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => {
        SceneManager.LoadScene("HandScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
    }
}