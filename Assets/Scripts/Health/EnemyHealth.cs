using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : Health
{
    public UnityEvent damageTakeEvent;
    public UnityEvent dieEvent;
    
    private void Start()
    {
        starthealth = 4;
        health = starthealth;
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
            dieEvent.Invoke();
            Destroy(this.gameObject);
        }
    }
}