using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorPuntos : MonoBehaviour
{
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
