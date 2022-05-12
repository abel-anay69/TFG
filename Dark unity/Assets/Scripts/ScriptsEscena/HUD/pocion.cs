using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pocion : MonoBehaviour
{
    public int valor = 4;
    public ContadorPuntos contadorPuntos;
    public AudioClip sonidoPocion;
    
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
            contadorPuntos.SumarPuntos(valor);
            Destroy(this.gameObject);
            AudioManagerMonedas.Instance.ReproducirSonido(sonidoPocion);
        }
        
    }
}
