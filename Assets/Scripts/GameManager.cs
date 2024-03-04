using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.ShaderData;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject defeat;
    public GameObject victory;
    public bool isPaused = false;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Paused();
            }
            else
            {
                Continue();
            }
        }
    }

    public void Game()
    {
        SceneManager.LoadScene("Juego");
    }

    public void Victory()
    {
        victory.SetActive(true);
        isPaused = true;
    }

    public void Defeat()
    {
        defeat.SetActive(true);
        isPaused = true;
    }
    public void Options()
    {
        optionsMenuUI.SetActive(true);
    }
    public void BackToMenu()
    {
        optionsMenuUI.SetActive(false);
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
        isPaused = false;
        Time.timeScale = 1f;
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
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MenuPrincipal");
    }
}
