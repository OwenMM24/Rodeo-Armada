using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float gravity_rising = -9.81f;
    public float gravity_falling = -9.81f * 3;
    public float gravity_fastfall = -9.81f * 3;
    public float speed_y = 0f;
    public float jumpHeight;
    public bool isGrounded;
    public bool isJumping;
    
    public RaycastHit2D hit;
    public Rigidbody2D rb;
    
    public float hangTime = .2f;
    public float hangCounter;
 
    public float jumpBufferLength = .1f;
    public float jumpBufferCounter;

    
    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;
    
    
    void Start()
    {
        isGrounded = false;
        isJumping = false;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
    	isGrounded = Physics2D.CircleCast(new Vector2(groundCheck.position.x, groundCheck.position.y), groundDistance, new Vector2(0f,0f), Mathf.Infinity, groundMask);
 	
 	if (speed_y < 0)
 	{
 	    isJumping = false;
 	}
 	
 	if (Input.GetAxisRaw("Vertical") == -1)
 	{
 	    speed_y += gravity_fastfall * Time.deltaTime;
 	}
 	else if (isJumping)
 	{
 	    speed_y += gravity_rising * Time.deltaTime;
 	}
 	else
 	{
 	    speed_y += gravity_falling * Time.deltaTime;
 	}
 	
        if(isGrounded)
        {
            //speed_y = -2f; This line makes jumping inconsistent for some reason.
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }
 
        if(Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferLength;
            Debug.Log("I'm trying to jump!");
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
 
        //allows for jumping
        if(jumpBufferCounter > 0f && hangCounter > 0f)
        {
            //handy formula for setting exact jump height
            speed_y = Mathf.Sqrt(jumpHeight * -2f * gravity_rising);
            jumpBufferCounter = 0;
            isJumping = true;
            Debug.Log("Jumping should be commencing!");
            Debug.Log(speed_y);
        }
 
        if (Input.GetButtonUp("Jump") && speed_y > 4f)
        {
            speed_y = 4f;
        }
        
        rb.velocity = new Vector2(0, speed_y);
    }
    
    
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }

}
