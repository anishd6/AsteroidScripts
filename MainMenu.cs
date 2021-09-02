using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {

        SceneManager.LoadScene("AsteroidArcadeClassic"); //should load menu then game onCLick
        Time.timeScale = 1;

    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void playRemix()
    {
        SceneManager.LoadScene("AsteroidArcadeRemix"); //should load menu then game onCLick
        Time.timeScale = 1;

    }
}
