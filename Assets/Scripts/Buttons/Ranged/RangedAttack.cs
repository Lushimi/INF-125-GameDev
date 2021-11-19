using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RangedAttack : Button
{
    public float staminaCost;
    public float cooldown;
    internal Animator animator => transform.parent.GetComponent<PlayerControl>().animator;

    public virtual void attack()
    {
    }
}
