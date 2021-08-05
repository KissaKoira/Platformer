using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_controller : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float speed = 5;
        float maxSpeed = 5;
        float stoppingSpeed = 5;

        if (rb.velocity.x < maxSpeed){

            rb.velocity += new Vector2(horizontal * speed * Time.deltaTime, 0);
        }

        if (horizontal == 0) {

            if (Mathf.Abs(rb.velocity.x) < 0.1f)
            {

                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            else {

                //rb.velocity = (rb.velocity.x / Mathf.Abs(rb.velocity.x)) - (stoppingSpeed * Time.deltaTime);
            }
        }
    }
}
