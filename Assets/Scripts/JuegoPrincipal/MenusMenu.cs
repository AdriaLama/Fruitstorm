using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusMenu : MonoBehaviour
{
    public GameObject Worlds;
    public GameObject optionsMenuUI;
    public bool hasCrucifix = false;
    public bool hasSpaceSuit = false;
    public bool hasSpacecraft = false;

    public void Game()
    {
        SceneManager.LoadScene("Juego");
        Time.timeScale = 1f;
    }
    public void Space()
    {
        SceneManager.LoadScene("Espacio");
        Time.timeScale = 1f;
    }

    public void Sky()
    {
        SceneManager.LoadScene("Cielo");
        Time.timeScale = 1f;
    }
    public void WorldMenu()
    {
        Worlds.SetActive(true);
    }

    public void Options()
    {
        optionsMenuUI.SetActive(true);
    }

    public void BackToMenu()
    {
        Worlds.SetActive(false);
        optionsMenuUI.SetActive(false);
    }

    public void GoEarth()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void GoSpace()
    {
        if (hasSpaceSuit)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("MenuEspacio");
        }
    }
    public void GoHeaven()
    {
        if (hasCrucifix)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("MenuCielo");
        }
    }

    public void Revenge()
    {
        if (hasSpacecraft)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("SpaceInvaders");
        }
    }
    public void Credits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Creditos");
    }
    public void Exit()
    {
        Application.Quit();
    }

    
}
