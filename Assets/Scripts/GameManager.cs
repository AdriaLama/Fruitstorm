using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) { 
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarJuego()
    {
        SceneManager.LoadScene("Juego");
    }

    public void CargarOpciones()
    {
        SceneManager.LoadScene("Opciones");
    }
    public void VolverMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

}
