using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : Health
{
    public UnityEvent damageTakeEvent;
    public UnityEvent dieEvent;
    public GameObject playerBodyObject;
    public GameObject MainObject;
    public ParticleSystem bloodGroundEffect;
    public float timeTillDestory = 8;
    public bool canTakeDamage = true;
    public GameObject enemy;
    private void Start()
    {
        starthealth = 4;
        health = starthealth;
    }

    public override void RemoveHealth(float amount)
    {
        if (canTakeDamage)
        {
            base.RemoveHealth(amount);
            damageTakeEvent.Invoke();
            StartCoroutine(DamageIndicatie());
        }
    }

    public override void Die()
    {
        if (health <= 0)
        {
            //makes sure it doesnt play twice.. (bugg fix)
            if (alive)
            {
                this.alive = false;
                dieEvent.Invoke();
                StartCoroutine(DestoryMainObject());
                bloodGroundEffect.enableEmission = false;
                Destroy(playerBodyObject);
                Destroy(this.GetComponent<EnemyMovement>());
            }
        }
    }

    public IEnumerator DestoryMainObject()
    {
        yield return new WaitForSeconds(timeTillDestory);
        Destroy(MainObject);
        yield return null;
    }

    public IEnumerator DamageIndicatie()
    {
        canTakeDamage = false;
        enemy.GetComponent<SpriteRenderer>().color = Color.red;  
        yield return new WaitForSeconds(1);
        enemy.GetComponent<SpriteRenderer>().color = Color.white;    
        canTakeDamage = true;
        yield return null;
    }
}