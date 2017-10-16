﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;

    // Use this for initialization
    void Start ()
    {
        quitMenu = quitMenu.GetComponent<Canvas>(); 
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
        
    }

    public void  ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true; 
    }

    public void StartMapScene()
    {
        Debug.Log("Empieza ingame");
        SceneManager.LoadScene("ingame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}