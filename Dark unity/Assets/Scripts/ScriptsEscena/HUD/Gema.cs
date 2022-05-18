using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gema : MonoBehaviour
{
    public int valor = 10;
    public ContadorPuntos contadorPuntos;
    public AudioClip sonidoGema;

    private bool estaColisionando;
    
    // Start is called before the first frame update
    void Start()
    {
        estaColisionando = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(estaColisionando) return;
            estaColisionando = true;
            Destroy(this.gameObject);
            AudioManagerMonedas.Instance.ReproducirSonido(sonidoGema);
            contadorPuntos.SumarPuntos(valor);
        }
        
    }
}
