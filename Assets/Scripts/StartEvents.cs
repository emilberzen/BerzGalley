using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Experimental.GlobalIllumination;
using TMPro;

public class StartEvents : MonoBehaviour
{

    public Image mouse;
    public Image keys;
    public Image esc;
    public Image background;


    public TextMeshProUGUI Instagram;
    public TextMeshProUGUI Facebook;
    public TextMeshProUGUI Mail;
    public TextMeshProUGUI EmilBerz;


    public GameObject[] StartUI;
    public GameObject[] ControlUI;


    public GameObject nextButton1;
    public GameObject nextButton2;
    public GameObject backButtton;

    public MouseLook mouseLook;
    public AudioSource audio;
    public GameObject MouseLook;
    public GameObject MoveControl;

    public Image gameEscImg;
    public TextMeshProUGUI gameEscText1;
    public TextMeshProUGUI gameEscText2;

    public GameObject escMenu;

    public bool experienceStarted;
    public bool escMenuActive;

     
   public void fadeStartScene()
    {

        nextButton1.SetActive(false);
        for (int i = 0; i < StartUI.Length; i++)
        {
            StartUI[i].GetComponent<TextMeshProUGUI>().DOFade(0,1f);
            
        }
        Invoke("ShowControlUI", 1f);
        Debug.Log("FADE START SCENE");
    }

    public void fadeInStartScene()
    {

        nextButton1.SetActive(true);
        for (int i = 0; i < StartUI.Length; i++)
        {
            StartUI[i].GetComponent<TextMeshProUGUI>().DOFade(1, 1f);

        }
        Debug.Log("FADE START SCENE");

    }



    public void ShowControlUI()
    {

        nextButton2.SetActive(true);
        backButtton.SetActive(true);
        mouse.DOFade(1, 1f);
        keys.DOFade(1, 1f);
        esc.DOFade(1, 1f);
        Debug.Log("SHOW CONTROLS");


        for (int i = 0; i < ControlUI.Length; i++)
        {
            ControlUI[i].GetComponent<TextMeshProUGUI>().DOFade(1, 0.5f);


        }


    }

    public void fadeOutControlUI()
    {

        nextButton2.SetActive(false);
        backButtton.SetActive(false);
        mouse.DOFade(0, 1f);
        keys.DOFade(0, 1f);
        esc.DOFade(0, 1f);
        Debug.Log("Hide CONTROLS");


        for (int i = 0; i < ControlUI.Length; i++)
        {
            ControlUI[i].GetComponent<TextMeshProUGUI>().DOFade(0, 0.5f);


        }

        Invoke("fadeInStartScene", 1);
    }

    public void startExperience()
    {
        MouseLook.GetComponent<MouseLook>().enabled = true;
        MoveControl.GetComponent<PlayerMovement>().enabled = true;
        audio.Play();
        mouse.DOFade(0, 1);
        keys.DOFade(0, 1);
        esc.DOFade(0, 1);
        background.DOFade(0, 1);
        Instagram.DOFade(0, 1);
        Facebook.DOFade(0, 1);
        Mail.DOFade(0, 1);

        gameEscImg.DOFade(1, 1);
        gameEscText2.DOFade(1, 1);
        gameEscText1.DOFade(1, 1);
        Debug.Log("START EXPERIENCE");
        for (int i = 0; i < ControlUI.Length; i++)
        {
            ControlUI[i].GetComponent<TextMeshProUGUI>().DOFade(0, 1);

        }

        experienceStarted = true;
        

    }

    public void exitESCmenu()
    {

        Cursor.lockState = CursorLockMode.Locked;
        escMenu.SetActive(false);
        background.DOFade(0f, 0.3f);
        MouseLook.GetComponent<MouseLook>().enabled = true;
        MoveControl.GetComponent<PlayerMovement>().enabled = true;
        gameEscImg.DOFade(1, 0);
        gameEscText2.DOFade(1, 0);
        gameEscText1.DOFade(1, 0);
        experienceStarted = true;
        escMenuActive = false;


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && experienceStarted)
        {
            background.DOFade(0.9f, 0.3f);
            escMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            MouseLook.GetComponent<MouseLook>().enabled = false;
            MoveControl.GetComponent<PlayerMovement>().enabled = false;
            experienceStarted = !experienceStarted;

            gameEscImg.DOFade(0, 0);
            gameEscText2.DOFade(0, 0);
            gameEscText1.DOFade(0, 0);
            escMenuActive = true;
        }


    }


}
