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
    
    public GameObject weaponPickUp;
    
    public GameManager gm;


    void Awake()
    {
        wavePosition = transform.position;
        startingPosition = transform.position;
        enemyTimer = 0;
        //random chance of 1 - 6 for if an enemy can drop a weapon
        int weaponDropChance = Random.Range(1, 2);
        if (weaponDropChance == 1)
        {
            dropWeapon = true;
        }
        
        GameObject game = GameObject.Find("Game Manager");
        gm = game.GetComponent<GameManager>();
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
        Vector3 point = transform.position;
    	if (col.tag == "Bullet")
	{
	    if (dropWeapon == true)
	    {
	    	Instantiate(weaponPickUp, point, Quaternion.identity);
	    }
	    gm.enemies_killed++;
            Destroy(this.gameObject);
	}
        
    }
}
