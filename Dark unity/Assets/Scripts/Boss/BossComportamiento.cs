using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossComportamiento : MonoBehaviour
{
    public Transform[] transforms;
    public GameObject llama;

    public float tiempoDisparo, countDown;
    public float tiempoTP, countDownTP;

    public float bossVida, vidaActual;
    public Image vidaImg;

    private void Start()
    {
        var posicionInicial = Random.Range(0, transforms.Length);
        transform.position = transforms[posicionInicial].position;
        //Esto lo que hara sera que cuando pasemos por el RigidBody y el jefe se active
        //aparecera en una de las 4 posiciones que tiene asignadas de forma aleatoria
        countDown = tiempoDisparo;
        countDownTP = tiempoTP;
    }

    private void Update()
    {
        CountDown();
        DamageBoss();
    }

    public void CountDown() //Esta funcion no tiene porque estar y los if's puede ir en el update, es por mera organización de código
    {
        countDown -= Time.deltaTime;
        countDownTP -= Time.deltaTime;

        if(countDown <= 0f)
        {
            DispararJugador();
            countDown = tiempoDisparo;
            Teletransporte();
        }

        if(countDownTP <= 0)
        {
            countDownTP = tiempoTP;
            Teletransporte();
        }
    }

    public void DispararJugador()
    {
        GameObject hechizo = Instantiate(llama, transform.position, Quaternion.identity);
        
    }

    public void Teletransporte()
    {
        var posicionInicial = Random.Range(0, transforms.Length);
        transform.position = transforms[posicionInicial].position;
    }

    public void DamageBoss()
    {
        vidaActual = GetComponent<Enemigo>().puntosVida;
        vidaImg.fillAmount = vidaActual / bossVida;
    }
}
