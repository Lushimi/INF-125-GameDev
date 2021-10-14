using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RangedAttack : Attack
{
    public override void attack()
    {
        // Play an ranged attack animation

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, range, enemyLayers);

        // Damage enemies (loop over all enemies in collider array)

    }
}
