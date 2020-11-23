using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    private void Start()
    {
        starthealth = 100;
        maxHealth = 100;
        health = starthealth;
    }

    public override void RemoveHealth(float amount)
    {
        if (health - amount < 0)
        {
            health = 0;
            updateUI();
            Die();
            return;
        }
        updateUI();
        health -= amount;
    }

    public override void AddHealth(float amount)
    {
        if (health + amount > maxHealth)
        {
            health = maxHealth;
            updateUI();
            return;
        }
        updateUI();
        health += amount;
    }

    public void updateUI()
    {
        //show new health in ui
    }

    public override void Die()
    {
    }
}