using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public PlayerControl playerControl;


    //bullets
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject lobber;
    public GameObject machine;

    //define current weapon
    public bool pistolEquip = true;
    public bool shotgunEquip = false;
    public bool lobberEquip = false;
    public bool machineEquip = false;
    
    //1 = pistol
    //2 = shotgun 
    //3 = lobber
    //4 = machine
    public int weaponEquip = 1;

    //shot cooldown
    public float timeBetweenShooting;

    //checks for rapid fire
    public bool allowButtonHold;

    //checks if player is currently shooting
    private bool shooting;

    //if player is ready to shoot next shot
    private bool readyToShoot;

    //where bullets come from
    public Transform attackPoint;

    public bool allowInvoke = true;

    //public float chargeTime;



    private void Awake()
    {
        //player is ready to shoot when the game starts
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = playerControl.isGrounded;
        MyInput();
        if (weaponEquip == 1)
    	{
    	    allowButtonHold = false;
    	    timeBetweenShooting = .03f;
    	}
        else if (weaponEquip == 2)
        {
    	    allowButtonHold = true;
    	    timeBetweenShooting = .5f;
        }
        else if (weaponEquip == 3)
        {
    	    allowButtonHold = true;
    	    timeBetweenShooting = 1f;
        }
        else if (weaponEquip == 4)
        {
    	    allowButtonHold = true;
    	    timeBetweenShooting = .05f;
        }
    }

    private void MyInput()
    {
        //checks if rapid fire is true
        if (allowButtonHold == true)
            shooting = Input.GetKey(KeyCode.Mouse0);
        else
            shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //calls shoot if ready to start creatinig bullets
        if (readyToShoot == true && shooting == true)
            Shoot();
        
        /*if (Input.GetMouseButtonDown(1))
        {
            weaponEquip++;
            if (weaponEquip > 4)
            {
            	weaponEquip = 1;
            }
            
        }*/
    }

    private void Shoot()
    {
        //if a shot has just been fired there is a cooldown
        readyToShoot = false;

        //creates a pistol bullet and gives it force
        if (weaponEquip == 1)
        {
            //sets bullet spawn point and rotation and creates bullet
            GameObject currentBullet = Instantiate(pistol, attackPoint.position, Quaternion.Euler(0, 0, 0));
        }

        //creates shotgun bullets and gives them force
        else if (weaponEquip == 2)
        {
        
        	if(playerControl.isGrounded == true){
        		//sets bullet spawn point and rotation and creates bullet 3 times
        		GameObject shotgunBullet1 = Instantiate(pistol, attackPoint.position, Quaternion.Euler(0, 0, 45));
        		GameObject shotgunBullet2 = Instantiate(pistol, attackPoint.position, Quaternion.Euler(0, 0, 35));
        		GameObject shotgunBullet3 = Instantiate(pistol, attackPoint.position, Quaternion.Euler(0, 0, 25));
        	} else{
        	        //sets bullet spawn point and rotation and creates bullet 3 times
        		GameObject shotgunBullet1 = Instantiate(pistol, attackPoint.position, Quaternion.Euler(0, 0, 330));
        		GameObject shotgunBullet2 = Instantiate(pistol, attackPoint.position, Quaternion.Euler(0, 0, 315));
        		GameObject shotgunBullet3 = Instantiate(pistol, attackPoint.position, Quaternion.Euler(0, 0, 300));
        	}

        }
        
        else if (weaponEquip == 3)
        {
        
        	if(playerControl.isGrounded == true){
        		//sets bullet spawn point and rotation and creates bullet 3 times
        		GameObject lobberBullet = Instantiate(lobber, attackPoint.position, Quaternion.Euler(0, 0, 80));
        	} else{
        	        //sets bullet spawn point and rotation and creates bullet 3 times
        		GameObject lobberBullet = Instantiate(lobber, attackPoint.position, Quaternion.Euler(0, 0, -5));
        	}

        }
        
        else if (weaponEquip == 4)
        {
        
        	
        
        
        
        
        	if(playerControl.isGrounded == true){
        		//sets bullet spawn point and rotation and creates bullet 3 times
        		GameObject machineBullet = Instantiate(machine, attackPoint.position, Quaternion.Euler(0, 0, 0));
        	} else{
        	        //sets bullet spawn point and rotation and creates bullet 3 times
        		GameObject machineBullet = Instantiate(machine, attackPoint.position, Quaternion.Euler(0, 0, 0));
        	}

        }

        if (allowInvoke == true)
        {
            //adds a delay between shots
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
    
    void InitializePistol()
    {
    	
    }
}
