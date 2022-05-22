using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossComportamiento : MonoBehaviour
{
    public Transform[] transforms;

    public GameObject llama;

    public static BossComportamiento instance;

    public float tiempoDisparo, recarga;
    public float tiempoTP, countDownTP;
    public float bossVida, vidaActual;

    public Image vidaImg;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        transform.position = transforms[1].position;
        //Esto lo que hara sera que cuando pasemos por el RigidBody y el jefe se active
        //aparecera en una de las 4 posiciones que tiene asignadas de forma aleatoria
        recarga = tiempoDisparo;
        countDownTP = tiempoTP;
    }

    private void Update()
    {        
        CountDown();
        DamageBoss();
        BossMirar();
    }

    public void CountDown() //Esta funcion no tiene porque estar y los if's puede ir en el update, es por mera organización de código
    {
        recarga -= Time.deltaTime;
        countDownTP -= Time.deltaTime;

        if(recarga < 0.0f)
        {
            DispararJugador();
            recarga = tiempoDisparo;
        }
        
        if(countDownTP < 0.0f)
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

    private void OnDestroy()
    {
        BossUI.instance.DesactivarBoss();
    }

    public void BossMirar() //Este metodo lo que hace es que el jefe siempre este mirando en la dirección del jugador
    {
        if(transform.position.x > JugadorMovimineto.instance.transform.position.x)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
