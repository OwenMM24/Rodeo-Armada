using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private GameManager gm;

    // Use this for initialization
    void Start()
    {
    	GameObject preGm = GameObject.Find("Game Manager");
        gm = preGm.GetComponent<GameManager>();
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();

        //Start the object moving.
        rb2d.velocity = new Vector2(-gm.scroll_speed, 0) * 5;

        if (rb2d.name == "Background")
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
    	rb2d.velocity = new Vector2(-gm.scroll_speed, 0) * 10;
    }
}
