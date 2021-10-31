using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeleeAttack : MonoBehaviour
{
    public Animator animator;
    public float cooldown = 0.25f;
    private Vector3 movementVector => gameObject.GetComponent<PlayerControl>().movementVector;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public int attackDamage = 40;
    public float attackRange = 0.5f;

    public void attack()
    {
        // Play an melee attack animation
        animator.SetFloat("lastMoveX", movementVector.x);
        animator.SetFloat("lastMoveY", movementVector.y);

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage enemies (loop over all enemies in collider array)
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<BossData>().TakeDamage(attackDamage, this.gameObject);
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
