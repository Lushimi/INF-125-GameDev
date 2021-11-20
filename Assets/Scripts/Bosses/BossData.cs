using System;
using UnityEngine;

[Serializable]
public class BossData : EntityData
{
    public int bossID;

    public override void Update()
    {
        if (isDamaged)
        {
            damageScreen.color = new Color(0f, 0f, 255f, 0.5f);
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, 5f * Time.deltaTime);
        }
        isDamaged = false;
    }

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
