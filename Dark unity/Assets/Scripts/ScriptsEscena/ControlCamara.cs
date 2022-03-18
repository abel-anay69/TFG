using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public Transform Jugador;

    

    public static ControlCamara instancia;

    private void Awake() 
    {
        if (instancia == null) 
        {
            instancia = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Jugador != null)
        {
            transform.position = new Vector3(Jugador.position.x, Jugador.position.y +0.7f, -10f);
        }

        
    }
}
