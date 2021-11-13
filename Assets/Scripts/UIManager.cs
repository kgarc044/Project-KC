using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked(Button b)
    {
        switch (b.name)
        {
            case "StartButton":
                SceneManager.LoadScene(sceneName: "PlayerCamera");
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
