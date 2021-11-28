﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;



public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PauseMenu;
    public GameObject Gun1, Gun2, Gun3, Gun4, Gun5;

    public Boolean PMenuActive;
    public static bool gameIsPaused;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        PauseMenu.gameObject.SetActive(false);

        PMenuActive = false;
        gameIsPaused = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        checkPauseMenu();
        checkKeyPress();

    }

    private void checkPauseMenu()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PMenuActive == true)
            {
                PauseMenu.gameObject.SetActive(false);
                PMenuActive = false;
                Time.timeScale = 1;
                gameIsPaused = false;
            }
            else if (PMenuActive == false)
            {
                PauseMenu.gameObject.SetActive(true);
                PMenuActive = true;
                Time.timeScale = 0;
                gameIsPaused = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    private void checkKeyPress()
    {
        var input = Input.inputString;
        switch (input)
        {
            case "1":
                gunReset();
                Gun1.gameObject.SetActive(true);
                break;
            case "2":
                gunReset();
                Gun2.gameObject.SetActive(true);
                break;
            case "3":
                gunReset();
                Gun3.gameObject.SetActive(true);
                break;
            case "4":
                gunReset();
                Gun4.gameObject.SetActive(true);
                break;
            case "5":
                gunReset();
                Gun5.gameObject.SetActive(true);
                break;
        }
    }
    
    private void gunReset()
    {
        if (Gun1.active) Gun1.gameObject.SetActive(false);
        else if (Gun2.active) Gun2.gameObject.SetActive(false);
        else if (Gun3.active) Gun3.gameObject.SetActive(false);
        else if (Gun4.active) Gun4.gameObject.SetActive(false);
        else if (Gun5.active) Gun5.gameObject.SetActive(false);
    }

    public void ButtonClicked(Button b)
    {
        switch (b.name)
        {
            case "StartButton":
                SceneManager.LoadScene(sceneName: "UI Scene");
                break;
            case "ContinueButton":
                PauseMenu.gameObject.SetActive(false);
                PMenuActive = false;
                Time.timeScale = 1;
                gameIsPaused = false;
                break;
            case "SettingsButton":
                break;
            case "QuitButton":
                UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
                break;
        }
    }
}
