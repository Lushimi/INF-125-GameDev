using System;
using UnityEngine;
using UnityEngine.UI;

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
    public bool isDead = false;
    public bool isDamaged = false;
    public Image damageScreen;

    [Header("Game Events")]
    [SerializeField]
    internal GameEvent HealthChanged;
    [SerializeField]
    internal GameEvent StaminaChanged;
    [SerializeField]
    internal GameEvent Death;
    [SerializeField]
    internal GameEvent SceneChanged;

  

    internal EntityControl entityControl => gameObject.GetComponent<EntityControl>();
    internal bool isInvulnerable => entityControl.isInvulnerable;
    internal Animator animator => entityControl.animator;

    abstract public void Reset();
    
    void Update()
    {
        if (isDamaged)
        {
            damageScreen.color = new Color(255f, 0f, 0f, 0.5f);
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, 5f * Time.deltaTime);
        }
        isDamaged = false;
    }
    
    public virtual void TakeDamage(int damage)
    {
        if (!isInvulnerable && !isDead)
        {
            isDamaged = true;
            currentHealth -= damage;
            HealthChanged.Raise();
            if (currentHealth <= 0)
            {
                Die();
            }
            entityControl.invulnOnHit();
        }
    }

    public virtual void TakeDamage(int damage, GameObject attacker)
    {
        if (!isInvulnerable && !isDead)
        {
            isDamaged = true;
            Rigidbody2D myRb = gameObject.GetComponent<EntityControl>().rb;
            currentHealth -= damage;
            HealthChanged.Raise();
            Vector3 knockbackVector = gameObject.transform.position - attacker.transform.position;
            myRb.AddForce((knockbackVector) * knockbackScale * myRb.mass * myRb.drag);

            if (currentHealth <= 0)
            {
                Die();
            }
            entityControl.invulnOnHit();
        }
    }

    public virtual void Die()
    {
        isDead = true;
        Debug.Log("Enemy died!");
        Death.Raise();
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
