using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
//using Json.Net;

public class RestManager : MonoBehaviour
{
    public static RestManager instance;

    public GameObject ranking;

    public Text infoText;

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
        StartCoroutine(GetRanking());
    }

    

    public IEnumerator GetRanking() // Obtenemos los datos de todos los usuarios pero nosotros solo mostraremos nombre y puntos
    {
        //infoText.text = "Cargando datos...";
        UnityWebRequest www = UnityWebRequest.Get("http://192.168.136.1:8080/usuarios");
        
        yield return www.SendWebRequest();
        

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error); //Aparecera dicho mensaje alguna o las dos condiciones de arriba se cumplen
        }
        else
        {
            Debug.Log(www.downloadHandler.text); //Muestra el resulta como texto

            JSONNode data = JSON.Parse(www.downloadHandler.text);

            JSONNode id = data[0];
            
            foreach(JSONNode puntuacion in data)
            {
                if(id["puntos"] < puntuacion["puntos"])
                {
                    id = puntuacion;
                }

                infoText.text += "Nombre: " +puntuacion["nombreUsuario"] +"/";
                infoText.text += "Puntos: " +puntuacion["puntos"] +"\n" +"\n";
            }

            infoText.text += "El usuario con mas puntos es " +id["nombreUsuario"] +" con " + id["puntos"] +" puntos";
        }

    }
}
