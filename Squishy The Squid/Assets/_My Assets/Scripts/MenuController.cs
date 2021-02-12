using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject pauseMenu = null;
    private bool paused = false;

    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PauseGame(bool setPause)
    {
        paused = setPause;
        if (paused == true)
        {
            //Open Pause Menu
            pauseMenu.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            //Close Pause Menu
            pauseMenu.GetComponent<Canvas>().enabled = false;
        }
    }

    public void CloseGame()
    { 
        Application.Quit();
    }
}
