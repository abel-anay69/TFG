using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{

    public float vida;
    public GameObject efectoMuerte;
    public float maxVida;
    bool Inmune;
    Blink material;
    SpriteRenderer sprite;
    public Image vidaImg; 

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        vida = maxVida;
    }

    // Update is called once per frame
    void Update()
    {
        vidaImg.fillAmount = vida / 100;

        if (vida > maxVida) 
        {
            vida = maxVida;
        }

    }

    public void subirVida (float num) {
        vida += num;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("enemigo") && !Inmune) 
        {
            vida -= collision.GetComponent<Enemigo>().damage;
            StartCoroutine(Inmunidad());
            AudioManager.instance.PlayAudio(AudioManager.instance.herido);

            if (vida <= 0)
            {

                vidaImg.fillAmount = vida = 0;
                Instantiate(efectoMuerte, transform.position, Quaternion.identity);
                Destroy(gameObject);
                AudioManager.instance.PlayAudio(AudioManager.instance.muerte);

            }
        }

        if(collision.CompareTag("Cura") && vida < 100 && !Inmune)
        {
            vida += 5;
            vidaImg.fillAmount += 5;
        }

        if(collision.CompareTag("Cura") && vida == 100 && !Inmune)
        {
            vida += 0;
            vidaImg.fillAmount += 0;
        }

        if(collision.CompareTag("Pocion") && vida < 100 && !Inmune)
        {
            vida += 50;
            vidaImg.fillAmount += 50;
        }

        if(collision.CompareTag("Pocion") && vida == 100 && !Inmune)
        {
            vida += 0;
            vidaImg.fillAmount += 0;
        }

        
    }

    IEnumerator Inmunidad() 
    {
        Inmune = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f);
        Inmune = false;
        sprite.material = material.original;
    }

    
}
