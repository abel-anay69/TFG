using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorPuntos : MonoBehaviour
{

    public static ContadorPuntos instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public int PuntosTotales
    {
        get
        {
            return puntosTotales;
        }
    }

    private int puntosTotales;

    public void SumarPuntos(int puntosSuma)
    {
        puntosTotales += puntosSuma;
        Debug.Log(puntosTotales);
    }
}
