using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MeleeAttackData
{
    public int meleeAttackType;
    public float cooldown;
    public int attackDamage;
    public float attackRange;


    public MeleeAttackData(MeleeAttack meleeAttack)
    {
        meleeAttackType = meleeAttack.meleeAttackType;
        cooldown = meleeAttack.cooldown;
        attackDamage = meleeAttack.attackDamage;
        attackRange = meleeAttack.attackRange;

    }
}
