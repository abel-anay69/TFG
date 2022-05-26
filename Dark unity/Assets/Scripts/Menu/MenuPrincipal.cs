using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BotonLogin()
    {
        SceneManager.LoadScene(1);// Poedmos poner tanto el nombre de la escena como el numero que tiene asignado en "Build Settings"
        
    }

    public void BotonRegistro()
    {
        SceneManager.LoadScene(1);
    }

    public void BotonSalir()
    {
        Debug.Log("Quitamos la aplicación");
        Application.Quit();
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene(0);
    }
}
