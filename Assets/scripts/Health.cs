using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float starthealth;
    public bool alive = true;



    public void TakeDamage(float value)
    {

        if (!alive)
        {
            return;
        }

        if (health <= 0)
        {
            health = 0;  
            alive = false; 
        }

        health -= value;


    }


}