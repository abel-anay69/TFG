using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class Login : MonoBehaviour
{
    public static Login instance;

    public InputField usuario;
    public InputField contra;

    string nombreUsuario;
    string password;

    //public string nombreUsuario;
    //public string password;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetLogin());
        
    }

    void update()
    {
        //StartCoroutine(GetLogin());
    }


    /*public IEnumerator GetInfo() // Obtenemos los datos de todos los usuarios pero nosotros solo mostraremos nombre y puntos
    {
        //infoText.text = "Cargando datos...";
        UnityWebRequest www = UnityWebRequest.Get("http://192.168.136.1:8080/usuarios/");
        
        yield return www.SendWebRequest();
        

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error); //Aparecera dicho mensaje alguna o las dos condiciones de arriba se cumplen
        }
        else
        {
            Debug.Log(www.downloadHandler.text); //Muestra el resultado como texto
        }
        
        StartCoroutine(GetLogin());

        
    }*/


    public IEnumerator GetLogin()
    {
        if(usuario.text == string.Empty && contra.text == string.Empty)
        {
           
            Debug.Log("Rellena los campos");
        }
        else
        {
            
            
            UnityWebRequest www = UnityWebRequest.Get("http://192.168.136.1:8080/usuarios/" +usuario +"/" +contra);
            
            yield return www.SendWebRequest();

            Debug.Log(www.downloadHandler.text);

        }    
    }

    
}
