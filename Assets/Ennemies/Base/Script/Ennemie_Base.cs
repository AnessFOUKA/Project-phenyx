using UnityEngine;

public class Enemie_Base : MonoBehaviour
{
    [Header("Stats générales")]
    public float maxHealth = 100f;
    public float moveSpeed = 2f;

    protected float currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {

    }

    public virtual void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
