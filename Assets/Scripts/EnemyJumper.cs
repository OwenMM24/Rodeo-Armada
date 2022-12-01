using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumper : MonoBehaviour
{

    public float jumpHeight;
    //public float jumpWhen;
    //public float jumpDistance;
    public float moveSpeed;
    public float jumpTime = 1;



    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(Vector3.right) * moveSpeed, ForceMode2D.Impulse);

	jumpTime = Random.Range(2, 6);

        Invoke("Jump", jumpTime);
    }

    // Update is called once per frame
    void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(Vector3.up) * jumpHeight, ForceMode2D.Impulse);
    }
    
    
    void OnTriggerEnter2D(Collider2D col)
    {
        Vector3 point = transform.position;
    	if (col.tag == "Bullet" || col.tag == "Player")
	{
		Destroy(this.gameObject);
	}
        
    }
    
    
}
