using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject MenuInicio;
    public GameObject GameOver;
    public GameObject Ganar;
    public GameObject Jugador;
    public GameObject Enemigo;
    public GameObject ConexionBotones;
    public static bool gameOver = false;
    public static bool start = false;
    public static bool victory = false;

    // Update is called once per frame
    void Update()
    {
        

        // Solo para el comienzo
        if (start == false)
        {
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                MenuInicio.SetActive(false);
                start = true;
               
            }
        }

        // Si muere el Jugador
        if (Jugador == null)
        {
            gameOver = true;
        }

        // Si mueren los enemigos, ganamos
        if (Enemigo == null)
        {
            victory = true;
        }

        // Cuando ganamos, cargamos el menu de victoria
        if (victory == true)
        {
            
            Ganar.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                victory = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                
            }
        }

        // Cuando perdemos, cargamos el menu de Game Over
        if (gameOver == true)
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.muerte);
            GameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                gameOver = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                
            }
        }
    }
}
