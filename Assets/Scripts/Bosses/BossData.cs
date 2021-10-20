using System;
using UnityEngine;

[Serializable]
public class BossData : EntityData
{

    public override void Reset()
    {
        currentHealth = bossVariables.maxHP;
        currentStamina = bossVariables.maxStamina;
        speed = bossVariables.speed;
        staminaPerSecond = bossVariables.staminaPerSecond;
        knockbackScale = bossVariables.knockbackScale;
}

}
