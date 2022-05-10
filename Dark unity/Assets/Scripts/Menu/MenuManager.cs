using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void BotonJugar()
    {
        //SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    public void BotonSalir()
    {
        Debug.Log("Quitamos la aplicación");
        Application.Quit();
    }
}
