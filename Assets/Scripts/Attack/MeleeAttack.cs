using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeleeAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public int attackDamage = 40;
    public float attackRange = 0.5f;

    public void attack()
    {
        // Play an melee attack animation
        animator.SetFloat("lastMoveX", Input.GetAxis("Horizontal"));
        animator.SetFloat("lastMoveY", Input.GetAxis("Vertical"));

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage enemies (loop over all enemies in collider array)
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<BossData>().TakeDamage(attackDamage);
        }

        animator.SetBool("isAttacking", true);

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
