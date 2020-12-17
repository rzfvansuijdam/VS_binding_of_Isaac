using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().RemoveHealth(5);
        }
    }
}
