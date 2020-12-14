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
}