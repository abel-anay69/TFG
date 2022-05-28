using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class Registro : MonoBehaviour
{

    public InputField nombreUsuario;
    public InputField password;

    public Text mensaje;


    string _id = "fdsfsd";
    int puntos = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void BotonRegistro() // Obtenemos los datos de todos los usuarios pero nosotros solo mostraremos nombre y puntos
    {
        if(nombreUsuario.text == string.Empty && password.text == string.Empty)
        {
           
            Debug.Log("Hasta los huevos");
        }
        else
        {
            StartCoroutine(Post(_id, nombreUsuario.text, password.text, puntos));
            Debug.Log("de locos");
        }   
    }

    public IEnumerator Post(string id, string usuario, string contra, int punto)
    {
        List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();
        wwwForm.Add(new MultipartFormDataSection("_id", id));
        wwwForm.Add(new MultipartFormDataSection("nombreUsuario", usuario));
        wwwForm.Add(new MultipartFormDataSection("password", contra));
        wwwForm.Add(new MultipartFormDataSection("puntos", punto.ToString()));

        UnityWebRequest www = UnityWebRequest.Post("http://192.168.136.1:8080/usuarios", wwwForm);

        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error); //Aparecera dicho mensaje alguna o las dos condiciones de arriba se cumplen
        }

        else
        {
            Debug.Log("De locos pa");
        }
    }
}
