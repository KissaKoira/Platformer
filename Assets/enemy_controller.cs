using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controller : MonoBehaviour
{
    Player enemy;
    GameObject player;

    Rigidbody2D rb;
    Vector2 move;
    float horizontal;
    void Start()
    {
        enemy = new Player(7f, 1.2f, 2.3f);
        player = GameObject.Find("player");

        rb = this.GetComponent<Rigidbody2D>();
        move = new Vector2(0, 0);
        horizontal = 0;
    }

    void Update()
    {
        move = new Vector2(move.x, rb.velocity.y);

        horizontal = Mathf.Sign(player.transform.position.x - transform.position.x);
        Debug.Log(horizontal);

        if (horizontal != 0)
        {
            move += new Vector2(horizontal * enemy.speed * Time.deltaTime, 0);

            if (Mathf.Abs(move.x) > enemy.maxSpeed)
            {
                move = new Vector2(enemy.maxSpeed * horizontal, move.y);
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
                move = new Vector2((Mathf.Abs(move.x) - (enemy.speed * Time.deltaTime)) * Mathf.Sign(move.x), move.y);
            }
            
        }

        /*if (Input.GetButtonDown("Jump") && grounded())
        {
            move = new Vector2(move.x, enemy.jumpPower);
        }*/
        
        rb.velocity = move;
    }

    bool grounded()
    {
        LayerMask mask = LayerMask.GetMask("Ground");

        if (Physics2D.OverlapCircle(transform.position - new Vector3(0, 0.03f, 0), this.GetComponent<CapsuleCollider2D>().size.y / 2, mask) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
