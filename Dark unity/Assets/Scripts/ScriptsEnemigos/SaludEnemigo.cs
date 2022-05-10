using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludEnemigo : MonoBehaviour
{
    Enemigo enemy;
    public GameObject efectoMuerte;
    public bool isDamaged;
    public ContadorPuntos contadorPuntos;
    SpriteRenderer sprite;
    Blink material;
    Rigidbody2D rd;

    private void Start() 
    {
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        enemy = GetComponent<Enemigo>();
        rd = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Arma") && !isDamaged) 
        {
            enemy.puntosVida -= 2f;

            if (collision.transform.position.x < transform.position.x)
            {
                rd.AddForce(new Vector2(enemy.knockbackX, enemy.knockbackY), ForceMode2D.Force);
            }
            else 
            {
                rd.AddForce(new Vector2(-enemy.knockbackX, enemy.knockbackY), ForceMode2D.Force);
            }

            StartCoroutine(Damager());

            if (enemy.puntosVida <= 0) 
            {
                Instantiate(efectoMuerte, transform.position, Quaternion.identity);
                AudioManager.instance.PlayAudio(AudioManager.instance.kill);
                Destroy(this.gameObject);
                contadorPuntos.SumarPuntos(enemy.puntos);
            }
        }
    }

    IEnumerator Damager() 
    {
        isDamaged = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
        sprite.material = material.original;
    }
}
