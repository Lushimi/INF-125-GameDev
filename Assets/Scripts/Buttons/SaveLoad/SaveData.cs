using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[KnownType(typeof(Dodge_Roll))]
[System.Serializable]
public class SaveData
{

    //public LoadoutManager loadout;

    public Dodge dodge;
    public MeleeAttack meleeAttack;
    public RangedAttack rangedAttack;
    public SpecialFireball specialAttack;
    public Parry parry;

    public int bossesDefeated;
}
