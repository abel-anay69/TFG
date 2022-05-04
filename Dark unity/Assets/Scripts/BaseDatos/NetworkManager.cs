using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public void CrearUsuario(string NombreUsuario, string Password, Action<Response> response)
    {
        StartCoroutine( CO_CrearUsuario(NombreUsuario, Password, response));
    }

    private IEnumerator CO_CrearUsuario(string NombreUsuario, string Password, Action<Response> response)
    {
        //Creamos un formulario para enviarle la informacion al servidor
        WWWForm form = new WWWForm();
        form.AddField("NombreUsuario", NombreUsuario);
        form.AddField("Password", Password);

        WWW w = new WWW("http://localhost/Juego/CrearUsuario.php", form);

        //El codigo no ve la respuesta instanteneamente, asi que ponemos un yield para poder esperar
        yield return w;

        response(JsonUtility.FromJson<Response>(w.text) );
        

    }   
}
[Serializable]
public class Response
{
    public bool done = false;
    public string messsage = "";
}
