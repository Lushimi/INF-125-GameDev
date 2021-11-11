using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ParryData
{
    public string parryType;
    public float startup;
    public float invuln;
    public float endLag;

    public ParryData(Parry parry)
    {
        parryType = parry.parryType;
        startup = parry.startup;
        invuln = parry.invuln;
        endLag = parry.endLag;
    }
}
