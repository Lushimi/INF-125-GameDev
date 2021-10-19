using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge_Roll : Dodge
{
    private void Reset()
    {
        staminaCost = 30f;
        startup = 0.025f;
        invuln = 0.4f;
        endLag = 0.25f;
        dodgeSpeedMultiplier = 2f;
    }

    void Start()
    {
        Reset();
    }

}
