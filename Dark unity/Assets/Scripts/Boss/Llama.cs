using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llama : MonoBehaviour
{
    float movimientoSpeed;
    Rigidbody2D rigidbody2D;
    Vector2 movimientoDireccion;
    JugadorMovimineto target;
    
    // Start is called before the first frame update
    void Start()
    {
        movimientoSpeed = GetComponent<Enemigo>().speed;
        rigidbody2D = GetComponent<Rigidbody2D>();
        target = JugadorMovimineto.instance;

        movimientoDireccion = (target.transform.position - transform.position).normalized * movimientoSpeed;
        rigidbody2D.velocity = new Vector2(movimientoDireccion.x, movimientoDireccion.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
