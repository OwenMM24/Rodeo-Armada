using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    /*
    Components needed:
    - Rigidbody 2D (set to Dynamic, Gravity Scale set to 0)
    - Collider 2D (ideally Capsule Collider 2D)
    - Transform, child of Player object
    
    Features include:
    - Adjustable jump height (tile-based)
    - Fastfalling (pressing down makes you fall faster)
    - Variable jump height (let go of jump while still going upwards and you will stop ascending)
    */
    
    //Variables, with ideal values and explanations when needed.
    
    //Various gravity variables. The idea behind this is that the best platformers have you ascend slowly and descend faster, which is what the first two variables are for.
    //When you press down while in midair, you'll fall even faster than descending gravity.
    //These variables affect speed_y.
    public float gravity_rising; //-19.62
    public float gravity_falling; //-39.24
    public float gravity_fastfall; //-98.1
    private float speed_y;
    
    public float jumpHeight; //3, number represents height in tiles.
    public bool isGrounded;
    private bool isJumping;
    
    private Rigidbody2D rb;
    public SpriteRenderer sprite;
    
    //Coyote time if you prefer. hangTime is the amount of time in seconds, after the player has run off of an edge, that the player has to jump.
    public float hangTime; //0.2f
    private float hangCounter;

    //An input buffer but for jumping. jumpBufferLength is the amount of time in seconds before the player hits the ground, that the player can press jump and the input will be accepted.
    public float jumpBufferLength; //0.1f
    private float jumpBufferCounter;

    //Necessary for the custom ground checking method. Unity's ground check is a bit finicky.
    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;
    
    public int health;
    public float iFrames; //seconds; amount of time that the player stays invincible after getting hit
    
    
    void Start()
    {
        isGrounded = false;
        isJumping = false;
        iFrames = 0;
        rb = GetComponent<Rigidbody2D>();
        //sprite = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
    	isGrounded = Physics2D.CircleCast(new Vector2(groundCheck.position.x, groundCheck.position.y), groundDistance, new Vector2(0f,0f), Mathf.Infinity, groundMask);
 	
 	if (speed_y < 0)
 	{
 	    isJumping = false;
 	}
 	
 	//gravity switching
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
 	
 	//coyote time
        if(isGrounded)
        {
            //speed_y = -2f; This line makes jumping inconsistent for some reason.
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }
 
 	//jump buffer
        if(Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferLength;
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
        }
 
        if (Input.GetButtonUp("Jump") && speed_y > 4f)
        {
            speed_y = 4f;
        }
        
        rb.velocity = new Vector2(0, speed_y);
        
        if (iFrames > 0)
        {
            sprite.enabled = !sprite.enabled;
            iFrames -= Time.deltaTime;
        }
        else
        {
            sprite.enabled = true;
            
        }
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    
    /*void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }
    }*/
    
    
    //Visualizes the ground check radius in the editor. 
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }
}
