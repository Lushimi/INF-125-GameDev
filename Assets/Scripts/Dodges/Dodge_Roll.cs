using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge_Roll : Dodge
{
    private void Reset()
    {
        staminaCost = 30f;
        startup = 0.2f;
        invuln = 0.4f;
        endLag = 0.4f;
        speed = 2f * gameObject.GetComponent<PlayerControl>().speed;
    }

    void Start()
    {
        Reset();
    }

}
