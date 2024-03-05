using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject shopMenuUI;
    public GameObject defeat;
    public GameObject victory;
    public bool isPaused = false;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (SceneManager.GetActiveScene().name == "Juego")
            {
                isPaused = !isPaused;
                if (isPaused && !optionsMenuUI.activeSelf)
                {
                    Pause();
                }
                else if (!isPaused && !optionsMenuUI.activeSelf)
                {
                    Resume();
                }
                else if (!isPaused && optionsMenuUI.activeSelf)
                {
                    isPaused = true;
                    if (isPaused && optionsMenuUI.activeSelf)
                    {
                        optionsMenuUI.SetActive(false);
                        Pause();
                    }
                }
            }
            else if (SceneManager.GetActiveScene().name == "MenuPrincipal")
            {
                if (optionsMenuUI.activeSelf || shopMenuUI.activeSelf)
                {
                    BackToMenu();
                }
                
            }
        }

    }

    public void Game()
    {
        SceneManager.LoadScene("Juego");
        Time.timeScale = 1f;
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
    public void BackToMenu()
    {
        optionsMenuUI.SetActive(false);
        shopMenuUI.SetActive(false);
    }

    public void Shop()
    {
        shopMenuUI.SetActive(true);
    }

    public void Pause()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        isPaused = false;
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

    public void OptionsMenu()
    {
        optionsMenuUI.SetActive(true);
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

    public void Exit()
    {
       Application.Quit();
        
    }
}
