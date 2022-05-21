using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossComportamiento : MonoBehaviour
{
    public Transform[] transforms;

    public static BossComportamiento instance;

    public float tiempoTP, countDownTP;

    public float bossVida, vidaActual;
    public Image vidaImg;

    private void Start()
    {
        transform.position = transforms[1].position;
        //Esto lo que hara sera que cuando pasemos por el RigidBody y el jefe se active
        //aparecera en una de las 4 posiciones que tiene asignadas de forma aleatoria
        countDownTP = tiempoTP;
    }

    private void Update()
    {
        CountDown();
        DamageBoss();
        //BossScale();
    }

    public void CountDown() //Esta funcion no tiene porque estar y los if's puede ir en el update, es por mera organización de código
    {
        countDownTP -= Time.deltaTime;

        if(countDownTP < 0.0f)
        {
            countDownTP = tiempoTP;
            Teletransporte();
        }
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

        if(vidaActual <= 0)
        {
            BossUI.instance.DesactivarBoss();
        }
    }

    /*public void BossScale()
    {
        if(transform.position.x > JugadorMovimineto.instance.transform.position.x)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }*/
}
