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

        pauseMenu = pauseMenu.GetComponent<Canvas>();
        pauseMenu.enabled = false;
    }

    public void OpenPauseMenu()
    {
        pauseMenu.enabled = true;
    }

    public void ClosePauseMenu()
    {
        pauseMenu.enabled = false;
    }

    public void NoPress()
    {
        ClosePauseMenu();
        changePauseStatus();
    }

    public void GoToIntroScene()
    {
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
