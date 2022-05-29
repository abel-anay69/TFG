using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pocion : MonoBehaviour
{
    public int valor = 4;
    public ContadorPuntos contadorPuntos;
    public AudioClip sonidoPocion;

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
            AudioManagerMonedas.Instance.ReproducirSonido(sonidoPocion);
            contadorPuntos.SumarPuntos(valor);
        } 
    }
}
