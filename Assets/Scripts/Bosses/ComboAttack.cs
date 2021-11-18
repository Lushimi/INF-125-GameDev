using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttack : MonoBehaviour
{
    public Animator animator;
    internal Rigidbody2D target => transform.GetComponent<BossControl>().target;
    public Transform attackPoint => transform.Find("MeleeAttackPoint");
    public LayerMask enemyLayers;

    public float health => transform.GetComponent<BossData>().currentHealth;

    public int attackDamage = 5;
    public float attackRangeNormal = 1.5f;
    public float finalAttackRange = 2.5f;
    public Rigidbody2D rb;

    public float startup = 0;
    public float firstmovelag = 0.8f;
    public float firstmovetracking = 0.2f;
    public float secondmovelag = 1.6f;
    public float secondmovetracking = 0.4f;
    public float finalattacklag = 2f;
    public float cooldown => startup + firstmovelag + secondmovelag + finalattacklag + firstmovetracking + secondmovetracking;

    public float movedistance = 1f;

    public float firstmovex = 1f;
    public float firstmovey = 0;

    public float secondmovex = -1f;
    public float secondmovey = 0;

    [SerializeField]
    internal GameEvent AttackSwing;
    [SerializeField]
    internal GameEvent ComboAttackSwing;

    [Header("AudioSources")]
    public AudioSource shine;
    public AudioSource slam;

    //Command
    public void comboAttack()
    {
        StartCoroutine(IComboAttack());
    }

    //Coroutine
    public IEnumerator IComboAttack()
    {
        if (!isDead()) 
        {
            yield return new WaitForSeconds(startup);
            animator.SetBool("comboP1", true);
        }
    }

    public void secondAttack()
    {
        animator.SetBool("comboP1", false);
        animator.SetBool("comboP2", true);

        StartCoroutine(MoveTowardsPlayer(firstmovetracking));
    }

    public void thirdAttack()
    {
        animator.SetBool("comboP2", false);
        animator.SetBool("comboP3", true);

        StartCoroutine(MoveTowardsPlayer(secondmovetracking));
    }

    public void finishAttack()
    {

        animator.SetBool("comboP3", false);
    }

    public void Boss_Combo_Attack()
    {

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRangeNormal, enemyLayers);
        AttackSwing.Raise();
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

    //Movement
    public IEnumerator MoveTowardsPlayer(float tracking_time)
    {
        if(!isDead())
        {
            gameObject.GetComponent<BossControl>().movement_override = true;
            gameObject.GetComponent<Pathfinding.AIPath>().canMove = true;
            float oldSpeed = gameObject.GetComponent<Pathfinding.AIPath>().maxSpeed;
            gameObject.GetComponent<Pathfinding.AIPath>().maxSpeed = 10;
            yield return new WaitForSeconds(tracking_time);
            gameObject.GetComponent<Pathfinding.AIPath>().canMove = false;
            gameObject.GetComponent<Pathfinding.AIPath>().maxSpeed = oldSpeed;
            gameObject.GetComponent<BossControl>().movement_override = false;
        }
    }

    public void PlayShineSFX()
    {
        shine.Play();
    }

    public void PlaySlamSFX()
    {
        slam.Play();
    }

    public bool isDead()
    {
        return health <= 0;
    }
}

