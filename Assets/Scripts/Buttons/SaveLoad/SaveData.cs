using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[System.Serializable]
public class SaveData
{

    public int dodge;
    public int meleeAttack;
    public int rangedAttack;
    public int specialAttack;
    public int parry;
    public int assist;

    public int[] bossesDefeated;
    public int[] dodgeUnlocked;
    public int[] meleeUnlocked;
    public int[] rangedUnlocked;
    public int[] specialUnlocked;
    public int[] parryUnlocked;
    public int[] assistUnlocked;
}