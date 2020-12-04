using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public UnityEvent damageTakeEvent;

    private void Start()
    {
        starthealth = 75;
        maxHealth = int.MaxValue;
        health = starthealth;
    }

    public override void RemoveHealth(float amount)
    {
        base.RemoveHealth(amount);
        damageTakeEvent.Invoke();
    }

    public override void AddHealth(float amount)
    {
        base.AddHealth(amount);
        damageTakeEvent.Invoke();
    }

    public override void Die()
    {
    }
}