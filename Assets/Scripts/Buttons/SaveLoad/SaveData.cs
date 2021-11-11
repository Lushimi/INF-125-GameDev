using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{

    public List<DodgeData> DodgeList;
    public List<MeleeAttackData> MeleeList;
    public List<RangedAttackData> RangedList;
    public List<SpecialFireballData> SpecialList;
    public List<ParryData> ParryList;

    public DodgeData dodge;
    public MeleeAttackData meleeAttack;
    public RangedAttackData rangedAttack;
    public SpecialFireballData specialAttack;
    public ParryData parryData;

    public int bossesDefeated;

    public SaveData (PlayerControl player)
    {

    }
}
