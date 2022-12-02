using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float scroll_speed;
    public int prev_enemies_killed;
    public int enemies_killed;
    // Update is called once per frame
    void Update()
    {
    	if (enemies_killed > prev_enemies_killed)
    	{
    	    scroll_speed -= 1f;
    	    enemies_killed = prev_enemies_killed;
    	}
        
    }
}
