using UnityEngine;

public class Health : MonoBehaviour
{
    protected float health;
    protected float starthealth;
    protected float maxHealth;
    protected bool alive = true;

    public virtual void Die()
    {
    }

    public virtual void RemoveHealth(float amount)
    {
        if (health - amount < 0)
        {
            health = 0;
            Die();
            return;
        }
        health -= amount;
    }

    public virtual void AddHealth(float amount)
    {
        if (health + amount > maxHealth)
        {
            health = maxHealth;
            return;
        }
        health += amount;
    }
}