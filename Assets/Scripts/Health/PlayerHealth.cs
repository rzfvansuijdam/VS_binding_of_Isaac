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
        base.RemoveHealth(amount);
        updateUI();
    }

    public override void AddHealth(float amount)
    {
        base.AddHealth(amount);
        updateUI();
    }

    public void updateUI()
    {
        //show new health in ui
    }

    public override void Die()
    {
    }
}