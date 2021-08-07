using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    Player player;
    Rigidbody2D rb;
    Vector2 move;
    float horizontal;
    void Start()
    {
        player = new Player(10f, 1.5f, 2.3f);
        rb = this.GetComponent<Rigidbody2D>();
        move = new Vector2(0, 0);
        horizontal = 0;
    }

    void Update()
    {
        move = new Vector2(move.x, rb.velocity.y);
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0)
        {
            move += new Vector2(horizontal * player.speed * Time.deltaTime, 0);

            if(Mathf.Abs(move.x) > player.maxSpeed)
            {
                move = new Vector2(player.maxSpeed * horizontal, move.y);
            }
        }
        else
        {
            if(Mathf.Abs(move.x) < 0.5f)
            {
                move = new Vector2(0, move.y);
            }
            else
            {
                move = new Vector2((Mathf.Abs(move.x) - (player.speed * Time.deltaTime)) * Mathf.Sign(move.x), move.y);
            }
            
        }

        if (Input.GetButtonDown("Jump") && grounded())
        {
            move = new Vector2(move.x, player.jumpPower);
        }
        
        rb.velocity = move;
    }

    bool grounded()
    {
        LayerMask mask = LayerMask.GetMask("Ground");

        if (Physics2D.OverlapCircle(transform.position - new Vector3(0, 0.04f, 0), this.GetComponent<CapsuleCollider2D>().size.y / 2 * 0.9f, mask) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
