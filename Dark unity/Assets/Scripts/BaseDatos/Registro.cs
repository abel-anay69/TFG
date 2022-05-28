using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class Registro : MonoBehaviour
{

    public static Registro instance;
    
    public InputField nombreUsuario;
    public InputField password;

    string _id = "fgf";
    string punto = "0";


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void BotonPulsado() // Obtenemos los datos de todos los usuarios pero nosotros solo mostraremos nombre y puntos
    {
        StartCoroutine(Post(_id, nombreUsuario.text, password.text, punto));
        
    }

    public IEnumerator Post(string id, string usuario, string contra, string punto)
    {
        if(nombreUsuario.text == string.Empty && password.text == string.Empty)
        {
            Debug.Log("Rellena los campos");
        }
        else
        {
            List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();
            wwwForm.Add(new MultipartFormDataSection("id", id));
            wwwForm.Add(new MultipartFormDataSection("nombreUsuario", usuario));
            wwwForm.Add(new MultipartFormDataSection("password", contra));
            wwwForm.Add(new MultipartFormDataSection("puntos", punto));

            UnityWebRequest www = UnityWebRequest.Post("http://192.168.136.1:8080/usuarios", wwwForm);

            yield return www.SendWebRequest();

            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error); //Aparecera dicho mensaje alguna o las dos condiciones de arriba se cumplen
            }
            else
            {
                Debug.Log("Usuario creado");
            }   
        }  
    }
}
