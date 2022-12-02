using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameManager gm;
    public int maxDistance;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject preGm = GameObject.Find("Game Manager");
        gm = preGm.GetComponent<GameManager>();
    }
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(gm.scroll_speed, 0);
        if (transform.position.x < maxDistance)
        {
            Destroy(this.gameObject);
        }
    }
    
    void OnTriggerEnter2d(Collider2D collision)
    {
        if (collision.tag == "Border")
            Destroy(this.gameObject);
    }
}
