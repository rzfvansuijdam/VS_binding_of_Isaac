using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : Health
{


    private void Start()
    {
        starthealth = 100;
        health = starthealth;
        alive = true; 

    }

    void OnCollisionEnter(Collision col)  
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(25);
            Debug.Log("player is taking damage");
        }

        if (health <= 0)
        {
            Debug.Log("dead");
        }
    }

    public void Update()
    {
        
      


        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}
