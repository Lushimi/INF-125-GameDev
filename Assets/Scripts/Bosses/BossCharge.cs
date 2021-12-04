using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharge : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint => transform.Find("MeleeAttackPoint");
    public LayerMask enemyLayers;

    public int attackDamage = 10;
    public float attackRangeNormal = 1.5f;
    public Rigidbody2D rb;
    [SerializeField]
    internal GameEvent AttackSwing;
    private BossControl Boss => gameObject.GetComponent<BossControl>();

    public float cooldown = 0.3f;
    public float staminaCost = 10f;
    public float chargeTimeout = 5f;

    public void attack()
    {
        startCharging();
    }


    public void startCharging()
    {
        //1
        animator.SetBool("isCharging", true);
        //next function is called through unity animation events
        //previously i used this to wait for the animation to finish: https://answers.unity.com/questions/1208395/animator-wait-until-animation-finishes.html    

    }

    public void finishedCharging() 
    {
        //2
        animator.SetBool("isChargeAttacking", true);
        animator.SetBool("isCharging", false);
        StartCoroutine(chargeAttacking());
    }

    public IEnumerator chargeAttacking()
    {
        Vector3 playerPos = Boss.target.transform.position;

        float timeout = chargeTimeout;
        while ( Vector3.Distance(transform.position, playerPos) > 0.5)
        {
            yield return null;
            float step = Boss.Boss.speed * 3 *Time.deltaTime; //boss boss lmao (it work tho)
            transform.position = Vector3.MoveTowards(transform.position, playerPos, step);
            timeout -= Time.deltaTime;
            if (timeout <= 0) timeoutFunc();
        }

        animator.SetBool("isChargeAttacking", false);
        animator.SetBool("isChargeAttackHitting", true);
    }

    public void timeoutFunc()
    {
        hit();
        animator.SetBool("isChargeAttacking", false);
        animator.SetBool("isChargeAttackHitting", true);
    }
    public void hit()
    {
        
        //3
        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRangeNormal, enemyLayers);
        AttackSwing.Raise();
        // Damage enemies (loop over all enemies in collider array)
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EntityData>().TakeDamage(attackDamage, this.gameObject);
            Debug.Log("Player damaged by charge attack!");
        }
        animator.SetBool("isChargeAttackHitting", false);
    }


    // 1. charge up + do charging up anim 
    // 2. run in a direction after charging + loop charging animation 
    // 3. hit player or timeout + go back to idle or movement anim

}
