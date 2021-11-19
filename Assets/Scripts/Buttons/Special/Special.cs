using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Special : Button
{ 
    public float staminaCost;
    public float cooldown;
    internal Animator animator => transform.parent.GetComponent<PlayerControl>().animator;

    public virtual void special()
    {
    }
}
