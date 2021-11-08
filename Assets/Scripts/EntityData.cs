using System;
using UnityEngine;

public abstract class EntityData : MonoBehaviour
{
    [Header("Readonly Variables")]
    //default values here
    [SerializeField]
    internal FloatVariable maxHP;
    [SerializeField]
    internal FloatVariable maxStamina;
    [SerializeField]
    internal BossVariables bossVariables;

    [Header("Entity Data")]
    //stats here
    public float speed;
    public float currentStamina = 0;
    public float currentHealth = 0;
    public float staminaPerSecond;
    public float knockbackScale = 100f;

    [Header("Game Events")]
    [SerializeField]
    internal GameEvent HealthChanged;
    [SerializeField]
    internal GameEvent StaminaChanged;

    internal bool isInvulnerable => gameObject.GetComponent<EntityControl>().isInvulnerable;

    abstract public void Reset();

    public virtual void TakeDamage(int damage)
    {
        if (!isInvulnerable)
        {
            currentHealth -= damage;
            HealthChanged.Raise();
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public virtual void TakeDamage(int damage, GameObject attacker)
    {
        if (!isInvulnerable)
        {
            Rigidbody2D myRb = gameObject.GetComponent<EntityControl>().rb;
            currentHealth -= damage;
            HealthChanged.Raise();
            Vector3 knockbackVector = gameObject.transform.position - attacker.transform.position;
            myRb.AddForce((knockbackVector) * knockbackScale * myRb.mass * myRb.drag);
            // Play hurt animation

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public virtual void Die()
    {
        Debug.Log("Enemy died!");
        // Die Animation

        // disable enemy
        gameObject.SetActive(false);

        // destroy enemy
        Destroy(gameObject);

        // Die Animation
    }

    public virtual void StaminaRegen()
    {
        if (bossVariables != null)
        {
            if (currentStamina < bossVariables.maxStamina)
            {
                currentStamina += Math.Min(100 - currentStamina, Time.deltaTime * staminaPerSecond);
                StaminaChanged.Raise();
            }
        }
        else if (currentStamina < maxStamina)
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
