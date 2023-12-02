using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Menu : MonoBehaviour
{

    public GameObject setPanel;
    public GameObject pauseMenu;
    public GameObject dieMenu;

    public void Play()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Settings(bool state)
    {
        setPanel.SetActive(state);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        dieMenu.SetActive(false);
    }
}
