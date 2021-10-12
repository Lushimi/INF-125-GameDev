using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpecialFireball : Special
{
    public GameObject projectile;
    public float projectileSpeed;

    public override void special()
    {
        GameObject fireball = Instantiate(projectile, transform) as GameObject;
        fireball.transform.parent = null;
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * projectileSpeed;
    }
}
