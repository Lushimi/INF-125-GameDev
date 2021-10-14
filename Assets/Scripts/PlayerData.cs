using System;
using UnityEngine;

[Serializable]
public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private FloatVariable maxHP;
    [SerializeField]
    private FloatVariable maxStamina;


    //player's buttons


    public float speed = 5f;

    public float currentStamina = 0;

    public float currentHealth = 0;

    public float staminaPerSecond = 3f;

    //Flag for checking if on-hit effects should apply
    public bool isInvulnerable = false;
    public bool canAct = true;

    [SerializeField]
    private GameEvent StaminaChanged;

    public void Reset()
    {
        currentHealth = maxHP;
        currentStamina = maxStamina;
    }
    public void StaminaRegen()
    {
        if (currentStamina < 100)
        {
            currentStamina += Math.Min(100 - currentStamina, Time.deltaTime * staminaPerSecond);
            StaminaChanged.Raise();
        }
    }

    public void ReduceStamina(float amount)
    {
        currentStamina -= amount;
        StaminaChanged.Raise();
    }

}
