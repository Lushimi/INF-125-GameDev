using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge_Blink : Dodge
{
    private void Reset()
    {
        staminaCost = 90f;
        speed = 1.5f * gameObject.GetComponent<PlayerControl>().speed;
    }

    void Start()
    {
        Reset();
    }

    public override void dodge() {
        gameObject.transform.position += gameObject.GetComponent<PlayerControl>().movementVector.normalized * speed;
    }
}
