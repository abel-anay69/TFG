using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public GameObject proyectil;

    public float tiempoDisparo;
    public float shootCoolDown;

    public bool watcher;
    public bool siempreDispara;

    // Start is called before the first frame update
    void Start()
    {
        shootCoolDown = tiempoDisparo;
    }

    // Update is called once per frame
    void Update()
    {
        if(siempreDispara)
        {
            shootCoolDown -= Time.deltaTime;

            if(shootCoolDown < 0)
            {
                Disparo();
            }
        }

        

        if(watcher)
        {

        }
    }

    public void Disparo()
    {
            GameObject fuego = Instantiate(proyectil, transform.position, Quaternion.identity);
            
            if(transform.localScale.x < 0)
            {
                fuego.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f), ForceMode2D.Force);
            }
            else
            {
                fuego.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0f), ForceMode2D.Force);
            }

            shootCoolDown = tiempoDisparo;
    }
}
