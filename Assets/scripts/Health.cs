using UnityEngine;

public class Health : MonoBehaviour
{
    protected float health;

    public float getHealth
    {
        get { return health; }
        set { health -= value; }
    }

    protected float starthealth;
    protected bool alive = true;

    public void Die()
    {
    }

    public virtual void TakeDemage(float amount)
    {
        health -= amount;
    }
}