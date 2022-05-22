using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivacionBoss : MonoBehaviour
{
    public GameObject bossGO;

    private void Start()
    {
        bossGO.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            BossUI.instance.ActivarBoss();//Con esto hacemos la llamada para que el jefe aparezca
            bossGO.SetActive(true);
            //StartCoroutine(WaitBoss());
        }
    }

    /*IEnumerator WaitBoss() //Este metodo hace que el jugador no se pueda mover mientras aparece el jefe
    {
        var currentSpeed = JugadorMovimineto.instance.speed;
        var currentJumpForce = JugadorMovimineto.instance.jumpForce;
        
        JugadorMovimineto.instance.jumpForce = 0;
        JugadorMovimineto.instance.speed = 0f;
        

        yield return new WaitForSeconds(2); 
        
        JugadorMovimineto.instance.speed = currentSpeed;
        JugadorMovimineto.instance.jumpForce = currentJumpForce;
        Destroy(gameObject);
    }*/
}
