using System;
using UnityEngine;

public abstract class EntityData : MonoBehaviour
{
    //default values here
    [SerializeField]
    internal FloatVariable maxHP;
    [SerializeField]
    internal FloatVariable maxStamina;
    [SerializeField]
    internal BossVariables bossVariables;

    //stats here
    public float speed;
    public float currentStamina = 0;
    public float currentHealth = 0;
    public float staminaPerSecond;
    public float knockbackScale = 100f;

    [SerializeField]
    internal GameEvent HealthChanged;
    [SerializeField]
    internal GameEvent StaminaChanged;

    abstract public void Reset();

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void TakeDamage(int damage, GameObject attacker)
    {
        Rigidbody2D myRb = gameObject.GetComponent<EntityControl>().rb;
        currentHealth -= damage;
        HealthChanged.Raise();
        Vector3 knockbackVector = gameObject.transform.position - attacker.transform.position;
        myRb.AddForce( (knockbackVector) * knockbackScale * myRb.mass * myRb.drag);
        // Play hurt animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log("Enemy died!");

        // disable enemy
        gameObject.SetActive(false);


        // Die Animation
    }

    public virtual void StaminaRegen()
    {
        if (currentStamina < 100)
        {
            currentStamina += Math.Min(100 - currentStamina, Time.deltaTime * staminaPerSecond);
            StaminaChanged.Raise();
        }
    }

    public virtual void ReduceStamina(float amount)
    {
        currentStamina -= amount;
        StaminaChanged.Raise();
    }
}
