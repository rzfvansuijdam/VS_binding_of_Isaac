using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public UnityEvent damageTakeEvent;

    private void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            RemoveHealth(1);
        }
        if (Input.GetKey(KeyCode.P))
        {
            AddHealth(1);
        }
    }

    private void Start()
    {
        maxHealth = int.MaxValue;
        health = starthealth;
        if (this.GetComponent<PlayerHealthInferface>() != null)
        {
            damageTakeEvent.AddListener(() =>
            {
                this.GetComponent<PlayerHealthInferface>().UpdateUI(health);
            });
            this.GetComponent<PlayerHealthInferface>().UpdateUI(health);
        }
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