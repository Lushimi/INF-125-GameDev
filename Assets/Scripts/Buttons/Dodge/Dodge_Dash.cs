using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge_Dash : Dodge
{
    private void Reset()
    {
        staminaCost = 65f;
        startup = 0.05f;
        invuln = 0.25f;
        endLag = 0.1f;
        dodgeSpeedMultiplier = 3.5f;
    }

    void Start()
    {
        Reset();
    }

}
