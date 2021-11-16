using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public int attackDamage = 5;
    public float attackRangeNormal = 1.5f;
    public float finalAttackRange = 2.5f;
    public Rigidbody2D rb;

    public float startup = 0;
    public float firstmovelag = 1f;
    public float secondmovelag = 2f;
    public float cooldown => startup + firstmovelag + secondmovelag;

    public float firstmovex = 1f;
    public float firstmovey = 0;

    public float secondmovex = -1f;
    public float secondmovey = 0;

    //Command
    public void comboAttack()
    {
        StartCoroutine(IComboAttack());
    }

    //Coroutine
    public IEnumerator IComboAttack()
    {
        yield return new WaitForSeconds(startup);
        attack();
        yield return new WaitForSeconds(firstmovelag);
        FirstMove();
        attack();
        yield return new WaitForSeconds(secondmovelag);
        SecondMove();
        attackFinal();

    }

    public void attack()
    {

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRangeNormal, enemyLayers);

        // Damage enemies (loop over all enemies in collider array)
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<PlayerData>().TakeDamage(attackDamage, this.gameObject);
            Debug.Log("Player damaged by combo attack!");
        }
    }

    //Final Combo Attack
    public void attackFinal()
    {

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, finalAttackRange, enemyLayers);

        // Damage enemies (loop over all enemies in collider array)
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<PlayerData>().TakeDamage(attackDamage, this.gameObject);
            Debug.Log("Player damaged by combo attack!");
        }
   
    }

    //Movement
    public void FirstMove()
    {
        rb.MovePosition(rb.position + new Vector2(firstmovex, firstmovey).normalized);
    }

    //Movement
    public void SecondMove()
    {
        rb.MovePosition(rb.position + new Vector2(secondmovex, secondmovey).normalized);
    }


}

