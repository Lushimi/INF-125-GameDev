using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge_Backflip : Dodge
{
    private void Reset()
    {
        staminaCost = 75f;
        startup = 0.2f;
        invuln = 1.2f;
        endLag = 0.6f;
        speed = (-1) * 1.5f * gameObject.GetComponent<PlayerControl>().speed;
    }

    void Start()
    {
        Reset();
    }
}
