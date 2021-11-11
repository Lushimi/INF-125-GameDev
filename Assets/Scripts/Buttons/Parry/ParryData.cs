using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ParryData
{
    public float startup;
    public float invuln;
    public float endLag;

    public int parryType;


    public ParryData(Parry parry)
    {
        startup = parry.startup;
        invuln = parry.invuln;
        endLag = parry.endLag;

        parryType = parry.parryType;
    }
}
