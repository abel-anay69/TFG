using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public ContadorPuntos contadorPuntos;
    public TextMeshProUGUI puntos;

    // Update is called once per frame
    void Update()
    {
        puntos.text = contadorPuntos.PuntosTotales.ToString();
    }
}
