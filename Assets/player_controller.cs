using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public GameObject pointer;
    public Camera camera;
    public GameObject[] pointer_trail;
    public GameObject magick_ball;

    Player player;
    float defaultSpeed;
    float defaultMaxSpeed;
    float defaultJumpPower;
    Rigidbody2D rb;
    Vector2 move;
    float horizontal;
    void Start()
    {
        player = new Player(10f, 1.5f, 2.3f);
        defaultSpeed = player.speed;
        defaultMaxSpeed = player.maxSpeed;
        defaultJumpPower = player.jumpPower;
        rb = this.GetComponent<Rigidbody2D>();
        move = new Vector2(0, 0);
        horizontal = 0;

        Cursor.visible = false;
    }

    void Update()
    {
        move = new Vector2(move.x, rb.velocity.y);
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0 && move.x < player.maxSpeed)
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

        //UI stuff
        Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        pointer.transform.position = new Vector3(mousePos.x, mousePos.y, 0);

        for(int i = 0; i < pointer_trail.Length; i++)
        {
            pointer_trail[i].transform.position = transform.position + ((pointer.transform.position - transform.position).normalized * 0.08f * (1 + ((i + 1) * 0.3f)));
        }

        //magick test
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject mb = GameObject.Instantiate(magick_ball);
            mb.transform.position = pointer_trail[0].transform.position;
            Vector2 pointerDir = (pointer.transform.position - transform.position).normalized;
            mb.GetComponent<Rigidbody2D>().velocity = pointerDir * 2;
        }
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

    
    public void slow(bool x)
    {
        if (x)
        {
            player.speed *= 0.3f;
            player.maxSpeed *= 0.3f;
            player.jumpPower *= 0.3f;
            Debug.Log("Slowed!");
        }
        else
        {
            player.speed = defaultSpeed;
            player.maxSpeed = defaultMaxSpeed;
            player.jumpPower = defaultJumpPower;
            Debug.Log("You are free!");
        }
        
    }
}
