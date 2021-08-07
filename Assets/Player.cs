using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public float speed;
    public float maxSpeed;

    public Player(float playerSpeed, float playerMaxSpeed)
    {
        speed = playerSpeed;
        maxSpeed = playerMaxSpeed;
    }
}
