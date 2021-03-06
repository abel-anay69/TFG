using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int valor = 5;
    public ContadorPuntos contadorPuntos;
    public AudioClip sonidoMoneda;

    private bool estaColisionando;

    // Update is called once per frame
    void Update()
    {
        estaColisionando = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(estaColisionando) return;
            estaColisionando = true;
            Destroy(this.gameObject);
            AudioManagerMonedas.Instance.ReproducirSonido(sonidoMoneda);
            contadorPuntos.SumarPuntos(valor);
        } 
    }  
}

