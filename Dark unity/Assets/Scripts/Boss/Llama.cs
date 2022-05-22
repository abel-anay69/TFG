using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llama : MonoBehaviour
{
    float moveSpeed;
    Rigidbody2D rigidbody2D;
    Vector2 moveDireccion;
    JugadorMovimineto target;

    void Start()
    {
        moveSpeed = GetComponent<Enemigo>().speed;
        rigidbody2D = GetComponent<Rigidbody2D>();
        target = JugadorMovimineto.instance;

        moveDireccion = (target.transform.position - transform.position).normalized * moveSpeed;
        rigidbody2D.velocity = new Vector2 (moveDireccion.x, moveDireccion.y);
    }
}
