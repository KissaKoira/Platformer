using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public float speed;
    public float maxSpeed;
    public float jumpPower;

    public Player(float playerSpeed, float playerMaxSpeed, float playerJumpPower)
    {
        speed = playerSpeed;
        maxSpeed = playerMaxSpeed;
        jumpPower = playerJumpPower;
    }
}
