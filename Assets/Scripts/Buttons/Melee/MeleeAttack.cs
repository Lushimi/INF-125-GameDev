using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[SerializeField]


public class MeleeAttack : MonoBehaviour
{

    private Vector3 movementVector => transform.parent.GetComponent<PlayerControl>().movementVector;
    public Transform attackPoint => transform.parent.GetComponent<PlayerControl>().MeleeAttackPoint;
    public Animator animator => transform.parent.GetComponent<PlayerControl>().animator;

    public LayerMask enemyLayers;

    public int attackDamage = 40;
    public float attackRange = 0.5f;
    public float cooldown = 0.25f;
    public int meleeAttackType;

    [SerializeField]
    internal GameEvent AttackSwing;

    public float cooldown = 0.25f;
    public int meleeAttackType;


    public void Awake()
    {
        LayerMask.NameToLayer("Enemies");
    }

    public void attack()
    {
        //Raise attack event
        AttackSwing.Raise();
        // Play an melee attack animation
        animator.SetFloat("lastMoveX", movementVector.x);
        animator.SetFloat("lastMoveY", movementVector.y);

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage enemies (loop over all enemies in collider array)
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Enemy Hit");
            enemy.GetComponent<BossData>().TakeDamage(attackDamage, transform.parent.gameObject);
        }

        animator.SetBool("isMeleeAttacking", true);

    }


    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void setMeleeAttackData(MeleeAttackData meleeAttack)
    {
        cooldown = meleeAttack.cooldown;
        attackDamage = meleeAttack.attackDamage;
        attackRange = meleeAttack.attackRange;
        meleeAttackType = meleeAttack.meleeAttackType;
    }
}
