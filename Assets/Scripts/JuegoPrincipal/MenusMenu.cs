using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusMenu : MonoBehaviour
{
    public GameObject Heaven;
    public GameObject Lock1;
    public GameObject OuterSpace;
    public GameObject Lock2;
    public GameObject Vengeance;
    public GameObject Lock3;
    public GameObject Worlds;
    public GameObject optionsMenuUI;

    private void Update()
    {
        if (GameManager.Instance.hasCrucifix)
        {
            Heaven.SetActive(true);
            Lock1.SetActive(false);
        }
        if (GameManager.Instance.hasSpaceSuit)
        {
            OuterSpace.SetActive(true);
            Lock2.SetActive(false);
        }
        if (GameManager.Instance.hasSpacecraft)
        {
            Vengeance.SetActive(true);
            Lock3.SetActive(false);
        }
    }
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
        if (GameManager.Instance.hasSpaceSuit)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("MenuEspacio");
        }
    }
    public void GoHeaven()
    {
        if (GameManager.Instance.hasCrucifix)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("MenuCielo");
        }
    }

    public void Revenge()
    {
        if (GameManager.Instance.hasSpacecraft)
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
