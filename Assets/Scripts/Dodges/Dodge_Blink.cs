using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge_Blink : Dodge
{
    private void Reset()
    {
        staminaCost = 90f;
        dodgeSpeedMultiplier = 1f;
    }

    void Start()
    {
        Reset();
    }

    public override void PerformDodge() 
    {
        gameObject.transform.position += gameObject.GetComponent<PlayerControl>().movementVector.normalized * Speed;
    }
}
