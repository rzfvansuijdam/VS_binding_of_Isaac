using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    private void Start()
    {
        starthealth = 100;
        health = starthealth;
    }

    public override void RemoveHealth(float amount)
    {
        if (health - amount < 0)
        {
            health = 0;
            Die();
            return;
        }
        health -= amount;
    }

    public override void AddHealth(float amount)
    {
        if (health + amount > maxHealth)
        {
            health = maxHealth;
            return;
        }
        health += amount;
    }

    public override void Die()
    {
    }
}