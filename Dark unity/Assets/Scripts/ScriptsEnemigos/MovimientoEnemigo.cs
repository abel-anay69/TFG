using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    float speed;
    Animator animator;
    public bool quieto, enMovimiento, movimientoDer;

    public Transform chequear, chequearMuro, chequearSuelo;
    public bool detectaFin, detectaMuro, detectaSuelo;
    public float radioDtectar;
    public LayerMask queSuelo;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        speed = GetComponent<Enemigo>().speed;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        detectaFin = !Physics2D.OverlapCircle(chequear.position, radioDtectar, queSuelo);
        detectaMuro = Physics2D.OverlapCircle(chequearMuro.position, radioDtectar, queSuelo);
        detectaSuelo = Physics2D.OverlapCircle(chequearSuelo.position, radioDtectar, queSuelo);

        if (detectaFin || detectaMuro && detectaSuelo) 
        {
            Vuelta();
        }
    }

    private void FixedUpdate() 
    {
        if (quieto) 
        {
            animator.SetBool("idle", true);
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (enMovimiento) 
        {
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

            if (!movimientoDer)
            {
                rigidbody2D.velocity = new Vector2(-speed * Time.deltaTime, rigidbody2D.velocity.y);
            }
            else 
            {
                rigidbody2D.velocity = new Vector2(speed * Time.deltaTime, rigidbody2D.velocity.y);
            }
        }
    }

    public void Vuelta() 
    {
        movimientoDer = !movimientoDer;
        transform.localScale *= new Vector2(-1, transform.localScale.y);
    }
}
