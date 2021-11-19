using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class MeleeAttack : Button
{

    internal Vector3 movementVector => transform.parent.GetComponent<PlayerControl>().movementVector;
    internal Transform attackPoint => transform.parent.GetComponent<PlayerControl>().MeleeAttackPoint;
    internal Animator animator => transform.parent.GetComponent<PlayerControl>().animator;

    public LayerMask enemyLayers;

    public int attackDamage;
    public float attackRange;
    public float cooldown;

    public virtual void attack()
    {
        
    }


    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
