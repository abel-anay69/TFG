using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarJugador : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && transform.GetComponentInParent<Proyectil>().watcher == true)
        {
            transform.GetComponentInParent<Proyectil>().Disparo(); //Ponemos "GetComponentInParent" ya que detectar enemigo es hijo de enemigo
        }
    }
}
