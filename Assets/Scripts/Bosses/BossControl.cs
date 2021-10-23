using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : EntityControl
{
    [SerializeField]
    internal BossData Boss;
    [SerializeField]
    internal Rigidbody2D target;
    [SerializeField]
    internal ComboAttack comboAttack;
    [SerializeField]
    internal Camera cam;
    //[SerializeField]
    //internal BossAI bossai;
    public bool verbose = false;
    public float decisionLocked = 0;
    public float meleeRange = 1f;
    public float roll = 0f;

    public float comboAttackDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Pathfinding.AIPath>().maxSpeed = Boss.speed;
        gameObject.GetComponent<Pathfinding.AIPath>().endReachedDistance = meleeRange;
        gameObject.GetComponent<Pathfinding.AIPath>().slowdownDistance = meleeRange + 0.5f;
        Boss.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        /*
0-70: check if target is in range of melee attack:
            yes: try to do melee combo if enough stamina, otherwise do a single melee attack
            no: try to get in range
 70-90: use a ranged attack on target
90-100: use a wave attack on target
*/
        Vector2 facing = (((target.position - rb.position) * 500).normalized);

        //update melee attack point
        GameObject matkp = gameObject.transform.Find("MeleeAttackPoint").gameObject;
        matkp.GetComponent<Transform>().position = rb.position + meleeRange * facing;

        //update ranged attack point
        GameObject ratkp = gameObject.transform.Find("RangedAttackPoint").gameObject;
        ratkp.GetComponent<Transform>().position = rb.position + 1f * facing;

        //update facing
        GameObject facingobj = gameObject.transform.Find("Facing").gameObject;
        facingobj.GetComponent<Transform>().position = facing;

        decisionLocked -= Time.deltaTime;
        gameObject.GetComponent<Pathfinding.AIPath>().canMove = false;
        if (canAct)
        {
            if (decisionLocked <= 0)
            {
                roll = Random.Range(0f, 100f);
            }
            
            if (roll <= 70)
            {
                if ((target.position - rb.position).magnitude < meleeRange)
                {
                    if (Boss.currentStamina > 50)
                    {
                        Boss.currentStamina = Boss.currentStamina - 50;
                        ComboAttack();
                        //yield return new WaitForSeconds(comboAttackDelay);
                        Invoke("MoveLeft", comboAttackDelay);
                        Invoke("ComboAttack", comboAttackDelay);
                        Invoke("MoveRight", comboAttackDelay+comboAttackDelay);
                        Invoke("ComboAttack", comboAttackDelay+comboAttackDelay);
                    }
                    else
                    {
                        if (verbose) Debug.Log("Trying to perform melee attack");
                    }


                }
                else
                {
                    gameObject.GetComponent<Pathfinding.AIPath>().canMove = true;
                    /*
                     * rudimentary implementation of following, replaced by A*
                    //Movement control
                    movementVector.x = target.position.x - rb.position.x;
                    movementVector.y = target.position.y - rb.position.y;
                    movementVector.z = 0;

                    rb.MovePosition(rb.position + new Vector2(movementVector.x, movementVector.y).normalized * Boss.speed * Time.fixedDeltaTime);
                    */
                }
                if (decisionLocked <= 0) decisionLocked = 3f;
            }
            else if (roll <= 90)
            {
                if (verbose) Debug.Log("Trying to perform ranged attack");
                if (decisionLocked <= 0) decisionLocked = 1f;
            }
            else
            {
                if (verbose) Debug.Log("Trying to perform wave attack");
                if (decisionLocked <= 0) decisionLocked = 0.5f;
            }


        }
    }
    void ComboAttack()
    {
        comboAttack.attack();
        Debug.Log("Boss Combo Attack");
    }

    void MoveLeft()
    {
        rb.MovePosition(rb.position + new Vector2(1f, 0).normalized);
    }

    void MoveRight()
    {
        rb.MovePosition(rb.position + new Vector2(1f, 0).normalized);
    }

}
