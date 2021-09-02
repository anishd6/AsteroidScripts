using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isRemix = false;
    
    public GameObject MyPauseMenu, PauseButton;
    public void Pause()
    {
        MyPauseMenu.SetActive(true);
        PauseButton.SetActive(false);

        Time.timeScale = 0; //stop time calling pause() 
    }

    public void Resume()
    {
        MyPauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1; //start time
    }


    public void MainMenu()
    {

        SceneManager.LoadScene("AsteroidArcadeMainMenu");

    }

    public void PauseQuit()
    {
        Application.Quit();
    }


}
