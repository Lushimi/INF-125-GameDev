using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[System.Serializable]
public class SaveData
{

    //public LoadoutManager loadout;

    //public DodgeData dodge;
    public MeleeAttackData meleeAttack;
    public RangedAttackData rangedAttack;
    public SpecialFireballData specialAttack;
    public ParryData parry;

    public int bossesDefeated;
}
