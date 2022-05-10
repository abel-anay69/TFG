using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int valor = 5;
    public ContadorPuntos contadorPuntos;
    public AudioClip sonidoMoneda;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            contadorPuntos.SumarPuntos(valor);
            AudioManagerMonedas.Instance.ReproducirSonido(sonidoMoneda);
        }
        
    }

    
}

