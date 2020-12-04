using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float starthealth;
    [SerializeField] protected float maxHealth;
    [SerializeField] protected bool alive = true;

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