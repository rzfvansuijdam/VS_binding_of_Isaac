using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : Health
{

    void Start()
    {
        starthealth = 100;
        health = starthealth;


    }

    private void Update()
    {



        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("bullet"))
        {
            TakeDamage(25);
        }
    }
}


