using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpecialFireballData
{
    public int specialType;


    public SpecialFireballData(SpecialFireball special)
    {
        specialType = special.specialType;
    }
}
