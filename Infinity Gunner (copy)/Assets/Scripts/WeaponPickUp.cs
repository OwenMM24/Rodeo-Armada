using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public float moveSpeed;
    //public Gun gun;
    public int gunPickUp;

    void Awake()
    {
        //makes to pick up move to the left on spawn
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(Vector2.right) * moveSpeed, ForceMode2D.Impulse);

    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        //random weapon choice
        gunPickUp = Random.Range(1, 5);
        Gun gun = other.GetComponent<Gun>();

        //changes the current weapon being used using integers
        if (other.tag == "Player")
        {
            if (gunPickUp == 1)
                gun.weaponEquip = 1;

            if (gunPickUp == 2)
                gun.weaponEquip = 2;

            if (gunPickUp == 3)
                gun.weaponEquip = 3;

            if (gunPickUp == 4)
                gun.weaponEquip = 4;
                
	    Destroy(this.gameObject);
        }
        
    }
} 

