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
        base.RemoveHealth(amount);
    }

    public override void AddHealth(float amount)
    {
        base.RemoveHealth(amount);
    }

    public override void Die()
    {
    }
}