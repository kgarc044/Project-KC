using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;



public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PauseMenu;

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
