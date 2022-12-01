using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitDetection : MonoBehaviour
{
    public PlayerControl player;
    public float maxIFrames;

    void OnTriggerEnter2D(Collider2D col)
    {
    	if (player.iFrames <= 0)
    	{
    	    if (col.tag == "Obstacle")
            {
                player.health--;
                player.iFrames = maxIFrames;
            }
    	}
    }
}
