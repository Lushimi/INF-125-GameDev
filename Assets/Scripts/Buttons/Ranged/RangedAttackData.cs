using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RangedAttackData
{
    public int rangedAttackType;
    public float cooldown;

    public RangedAttackData(RangedAttack rangedAttack)
    {
        rangedAttackType = rangedAttack.rangedAttackType;
        cooldown = rangedAttack.cooldown;
    }

}