using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge_Backflip : Dodge
{
    private void Reset()
    {
        staminaCost = 65f;
        startup = 0.025f;
        invuln = .45f;
        endLag = 0.3f;
        dodgeSpeedMultiplier = (-1) * 3f;
    }

    void Start()
    {
        Reset();
    }
}
