using System;
using UnityEngine;

[Serializable]
public class PlayerData : EntityData
{
    public override void Reset()
    {
        currentHealth = maxHP;
        currentStamina = maxStamina;
        speed = 5f;
        staminaPerSecond = 3f;
    }

}
