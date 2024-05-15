using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusGame : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject shopMenuUI;
    public GameObject defeat;
    public GameObject victory;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (SceneManager.GetActiveScene().name == "Juego" && !(optionsMenuUI.activeInHierarchy))
            {
                isPaused = !isPaused;
                if (isPaused)
                {
                    Paused();
                }
                else if (!isPaused)
                {
                    Continue();
                }
            }
            else if (SceneManager.GetActiveScene().name == "Cielo" && !(optionsMenuUI.activeInHierarchy))
            {
                isPaused = !isPaused;
                if (isPaused)
                {
                    Paused();
                }
                else if (!isPaused)
                {
                    Continue();
                }
            }
            else if (SceneManager.GetActiveScene().name == "Espacio" && !(optionsMenuUI.activeInHierarchy))
            {
                isPaused = !isPaused;
                if (isPaused)
                {
                    Paused();
                }
                else if (!isPaused)
                {
                    Continue();
                }
            }
            else if (SceneManager.GetActiveScene().name == "SpaceInvaders" && !(optionsMenuUI.activeInHierarchy))
            {
                isPaused = !isPaused;
                if (isPaused)
                {
                    Paused();
                }
                else if (!isPaused)
                {
                    Continue();
                }
            }
        }
    }
    public void Victory()
    {
        victory.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Defeat()
    {
        defeat.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }
    public void Options()
    {
        optionsMenuUI.SetActive(true);
    }
    public void Shop()
    {
        shopMenuUI.SetActive(true);
        victory.SetActive(false);
        defeat.SetActive(false);
    }

    public void Pause()
    {
        isPaused = !isPaused;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        isPaused = !isPaused;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToPause()
    {
        optionsMenuUI.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void QuitSky()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MenuCielo");
    }

    public void QuitSpace()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MenuEspacio");
    }
}
