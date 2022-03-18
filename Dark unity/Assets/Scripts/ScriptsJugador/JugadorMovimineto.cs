using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimineto : MonoBehaviour
{

    public float speed, jumpForce;
    float velX, velY;
    private Rigidbody2D rigidbody2D; 
    private float Horizontal;
    private bool Grounded;
    Animator anim;
    public float knockbackX;
    public float knockbackY;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimineto
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        if(rigidbody2D.velocity.x != 0)
        {
            anim.SetBool("andar", true);
        }
        else
        {
            anim.SetBool("andar", false);
        }

        Debug.DrawRay(transform.position, Vector3.down * 0.32f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.32f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if(Grounded)
        {
            anim.SetBool("saltar", false);
        }
        else
        {
            anim.SetBool("saltar", true);
        }

        //Saltar
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
            AudioManager.instance.PlayAudio(AudioManager.instance.jump);
        }

        //Atacar
        Atacar();
       
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(Horizontal * speed, rigidbody2D.velocity.y);
    }

    public void Atacar()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("atacar", true);
            AudioManager.instance.PlayAudio(AudioManager.instance.hit);
        }
        else
        {
            anim.SetBool("atacar", false);
        }
    }

    public void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * jumpForce);
    }
}
