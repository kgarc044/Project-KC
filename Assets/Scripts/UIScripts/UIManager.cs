﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public  GameObject PauseMenu;
    public  GameObject InvMenu;
    //public GameObject Gun1, Gun2, Gun3, Gun4, Gun5;
    public  GameObject gunImg;
    public  GameObject noGunText;
    private GameObject activeGun;
    [SerializeField]
    private GameObject Player;


    public Image manaBar;
    public Image healthBar;

    public CanvasGroup Messages;

    public Boolean PMenuActive;
    public static bool gameIsPaused;

    /*[SerializeField] public ResourceBar healthBar;
    [SerializeField] public ResourceBar manaBar;*/

    public Text ammoCount;


    //private static Scene LastScene;
    //private static String LastSceneName;
    private bool fadeOut = false;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        PauseMenu.gameObject.SetActive(false);

        PMenuActive = false;
        gameIsPaused = false;

        Player = GameObject.Find("Player");

        //healthBar.SetSize(.5f);
        //healthBar.SetRegen(.00005f);
        //manaBar.SetSize(.5f);
        //manaBar.SetRegen(.0002f);
        manaBar.fillAmount = Player.GetComponent<PlayerMove>().mana.ReturnResource();
        healthBar.fillAmount = Player.GetComponent<PlayerMove>().health.ReturnResource();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(manaBar.ReturnVal());
        CheckPauseMenu();
        if (!gameIsPaused)
        {
            CheckKeyPress();
            CheckHitpoints();
            CheckGun();
            if (fadeOut == true)
            {
                FadeTxt();
            }
        }
    }

    private void CheckPauseMenu()
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

    private void CheckKeyPress()
    {
        var input = Input.inputString;
        switch (input)
        {
            /*case "1":
                manaBar.Decrease(.2f);
                break;
            case "2":
                manaBar.Decrease(.3f);
                break;
            case "3":
                manaBar.Decrease(.4f);
                break;
            case "4":
                Player.GetComponent<PlayerMove>().mana.Decrease(.5f);
                break;*/
            case "5":
                Player.GetComponent<PlayerMove>().mana.Decrease(.6f);
                break;/**/
            case "6":
                Player.GetComponent<PlayerMove>().health.Increase(.1f);
                break;
            case "7":
                Player.GetComponent<PlayerMove>().health.Decrease(.2f);
                break;
            case "8":
                Player.GetComponent<PlayerMove>().mana.Increase(.2f);
                break;
            /*case "9":
                Player.GetComponent<PlayerMove>().mana.Decrease(.1f);
                break;*/
        }
    }

    private void CheckHitpoints()
    {
        manaBar.fillAmount = Player.GetComponent<PlayerMove>().mana.ReturnResource();
        healthBar.fillAmount = Player.GetComponent<PlayerMove>().health.ReturnResource();
        Player.GetComponent<PlayerMove>().health.Update();
        Player.GetComponent<PlayerMove>().mana.Update();

        if (Player.GetComponent<PlayerMove>().health.ReturnResource() == 0)
        {
            //LastScene = SceneManager.GetActiveScene();
            //LastSceneName = UnityEngine.SceneManagement.Scene.name;
            SceneManager.LoadScene(sceneName: "LoseMenu");
        }
        }

    private void CheckGun()
    {
        if (GameObject.FindGameObjectsWithTag("Gun").Length != 0)
        {
            activeGun = GameObject.FindGameObjectsWithTag("Gun")[0];
            gunImg.gameObject.GetComponent<Image>().sprite = activeGun.GetComponent<SpriteRenderer>().sprite;

            noGunText.gameObject.SetActive(false);
            gunImg.gameObject.SetActive(true);

            ammoCount.text = string.Format("{0}", activeGun.GetComponent<GunBase>().ammoTotal) + "/" + activeGun.GetComponent<GunBase>().ammoMax;
        }
        else
        {
            gunImg.gameObject.SetActive(false);
            noGunText.gameObject.SetActive(true);
        }
    }

        /*private void gunReset()
        {
            if (Gun1.active) Gun1.gameObject.SetActive(false);
            else if (Gun2.active) Gun2.gameObject.SetActive(false);
            else if (Gun3.active) Gun3.gameObject.SetActive(false);
            else if (Gun4.active) Gun4.gameObject.SetActive(false);
            else if (Gun5.active) Gun5.gameObject.SetActive(false);
        }*/

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
            case "TryAgainButton":
                SceneManager.LoadScene(sceneName: "LevelTest1");
                break;
            case "MainMenuButton":
                SceneManager.LoadScene(sceneName: "MainMenu");
                break;
            case "QuitButton":
                UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
                break;
            case "InventoryButton":
                PauseMenu.gameObject.SetActive(false);
                InvMenu.gameObject.SetActive(true);
                break;
            case "InvBackButton":
                InvMenu.gameObject.SetActive(false);
                PauseMenu.gameObject.SetActive(true);
                break;
        }
    }

    public void PopText(String msg)
    {
        Messages.alpha = 1;
        fadeOut = true;
    }
    public void FadeTxt()
    {
        if (Messages.alpha >= 0)
        {
            Messages.alpha -= Time.deltaTime;
            if (Messages.alpha == 0) fadeOut = false;
        }
    }
}
