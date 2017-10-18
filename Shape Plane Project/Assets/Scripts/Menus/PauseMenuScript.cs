using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuScript : MonoBehaviour
{
    public Canvas pauseMenu;
    private bool isPaused;

    // Use this for initialization
    void Start()
    {
        isPaused = false;
        
        pauseMenu.enabled = false;
    }

    public void OpenPauseMenu()
    {
        Debug.Log("open Pause");

        pauseMenu.enabled = true;
    }

    public void ClosePauseMenu()
    {
        Debug.Log("close pause");

        pauseMenu.enabled = false;
    }

    public void NoPress()
    {
        ClosePauseMenu();
        changePauseStatus();
    }

    public void GoToIntroScene()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<ArduinoThreadMovoment>().getPortNames().Length >= 2)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<ArduinoThreadMovoment>().closeMovePort();
            GameObject.FindGameObjectWithTag("Player").GetComponent<ArduinoThreadMovoment>().closeRotatePort();
        }

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        SceneManager.LoadScene("Intro");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pause");
            changePauseStatus();
            if (isGamePaused())
            {
                OpenPauseMenu();
            }else{
                ClosePauseMenu();
            }
        }
            
    }


    public void changePauseStatus()
    {
        if (isPaused)
        {
            isPaused = false;
        }
        else
        {
            isPaused = true;
        }
    }

    public bool isGamePaused()
    {
        return isPaused;
    }
}
