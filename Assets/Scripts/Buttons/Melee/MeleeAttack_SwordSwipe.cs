using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack_SwordSwipe : MeleeAttack
{
    public void Awake()
    {
        LayerMask.NameToLayer("Enemies");
    }

    public override void attack()
    {
        // Play an melee attack animation
        animator.SetFloat("lastMoveX", movementVector.x);
        animator.SetFloat("lastMoveY", movementVector.y);

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage enemies (loop over all enemies in collider array)
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Enemy Hit");
            enemy.GetComponent<BossData>().TakeDamage(attackDamage, transform.parent.gameObject);
        }

        animator.SetBool("isMeleeAttacking", true);

    }
}
