using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpecialFireball : Special
{
    public GameObject projectile;
    public float projectileSpeed = 10;

    public override void special()
    {
        GameObject fireball = Instantiate(projectile, transform) as GameObject;
        fireball.transform.parent = null;
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * projectileSpeed;
    }
}
