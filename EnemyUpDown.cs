using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpDown : MonoBehaviour
{
    //the y position of the enemy when it is created in the scene
    public Vector2 startingPosition;
    // current position on the sin graph
    public Vector2 wavePosition;
    // left/right speed
    public float horizontalSpeed;
    // up/down speed
    public float verticalSpeed;
    // how high and how low it can travel
    public float waveHeight;


    void Awake()
    {
        wavePosition = transform.position;
        startingPosition = transform.position;
    }


    void FixedUpdate()
    {
        //defines x and y positions
        wavePosition.x += horizontalSpeed;
        wavePosition.y = startingPosition.y + Mathf.Sin(Time.time * verticalSpeed) * waveHeight;
        //sets the x and y positions to be the game objects current position
        transform.position = wavePosition;
    }
}
