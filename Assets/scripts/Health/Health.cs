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
        health -= amount;
    }

    public virtual void AddHealth(float amount)
    {
        health += amount;
    }
}