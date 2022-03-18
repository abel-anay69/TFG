using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muros : MonoBehaviour
{
    Rigidbody2D rd;
    public JugadorMovimineto ju;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.position.x < transform.position.x)
            {
                rd.AddForce(new Vector2(ju.knockbackX, ju.knockbackY), ForceMode2D.Force);
            }
            else
            {
                rd.AddForce(new Vector2(-ju.knockbackX, ju.knockbackY), ForceMode2D.Force);
            }
        }
    }
}
