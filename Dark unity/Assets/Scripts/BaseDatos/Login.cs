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
    int puntos;



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

    public void BotonPulsado()
    {
        StartCoroutine(LoginClick());
    }

    public IEnumerator LoginClick()
    {
        Debug.Log(usuario.text +contra.text);
        
        if(usuario.text == "" && contra.text == "")
        {
           
            Debug.Log("Rellena los campos");
        }
        else
        {
            
            UnityWebRequest www = UnityWebRequest.Get($"http://192.168.136.1:8080/usuarios/{usuario.text}/{contra.text}");
            
            yield return www.SendWebRequest();

            Debug.Log(www.downloadHandler.text);

            

            JSONNode data = JSON.Parse(www.downloadHandler.text);

            if(data)
            {
                nombreUsuario = data["nombreUsuario"];
                password = data["password"];
                puntos = data["puntos"];

                Debug.Log(nombreUsuario +" " +password +" " +puntos);
            }
            else
            {
                Debug.Log("El usuario no existe, intentelo otra vez");
            }
        }    
    } 
}
