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
    //local timer
    public float enemyTimer;
    //sees if an enemy will drop a weapon
    public bool dropWeapon = false;


    void Awake()
    {
        wavePosition = transform.position;
        startingPosition = transform.position;
        enemyTimer = 0;
        //random chance of 1 - 6 for if an enemy can drop a weapon
        int weaponDropChance = Random.Range(1, 7);
        if (weaponDropChance == 1)
        {
            dropWeapon = true;
        }
    }
    
    void Update()
    {
    	enemyTimer += Time.deltaTime;
    }


    void FixedUpdate()
    {
        //defines x and y positions
        wavePosition.x += horizontalSpeed;
        wavePosition.y = startingPosition.y + Mathf.Sin(enemyTimer * verticalSpeed) * waveHeight;
        //sets the x and y positions to be the game objects current position
        transform.position = wavePosition;
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
    	if (col.tag == "Bullet")
	{
            Destroy(this.gameObject);
	}
        
    }
}
