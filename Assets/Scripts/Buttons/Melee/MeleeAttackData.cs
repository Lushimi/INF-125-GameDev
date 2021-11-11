using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MeleeAttackData
{
    public float cooldown;
    public int attackDamage;
    public float attackRange;

    public int meleeAttackType;

    public MeleeAttackData(MeleeAttack meleeAttack)
    {
        cooldown = meleeAttack.cooldown;
        attackDamage = meleeAttack.attackDamage;
        attackRange = meleeAttack.attackRange;
        meleeAttackType = meleeAttack.meleeAttackType;
    }
}
