using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : Health
{
    public UnityEvent damageTakeEvent;

    private void Start()
    {
        starthealth = 4;
        health = starthealth;
    }

    public void Update() {


    }

   public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullet")
            RemoveHealth(1);
        Debug.Log("got em");
    }

    public override void RemoveHealth(float amount)
    {
        base.RemoveHealth(amount);
        damageTakeEvent.Invoke();
    }

    public override void Die()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}