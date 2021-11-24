using System;
using UnityEngine;

[Serializable]
public class BossData : EntityData
{
    public int bossID;


    public override void Reset()
    {
        currentHealth = bossVariables.maxHP;
        HealthReset.Raise();
        currentStamina = bossVariables.maxStamina;
        speed = bossVariables.speed;
        staminaPerSecond = bossVariables.staminaPerSecond;
        knockbackScale = bossVariables.knockbackScale;
    }


    public override void Die()
    {
        isDead = true;
        Death.Raise();
        Debug.Log("Boss " + bossID + " died!");
    }


}
