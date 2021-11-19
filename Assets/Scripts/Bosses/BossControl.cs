using System.Collections;
using UnityEngine;

public class BossControl : EntityControl
{

    [Header("Boss")]
    [SerializeField]
    internal BossData Boss;
    [SerializeField]
    internal Rigidbody2D target;
    [SerializeField]
    internal Camera cam;

    [Header("Moves")]
    [SerializeField]
    internal BossMeleeAttack meleeAttack;
    [SerializeField]
    internal ComboAttack comboAttack;
    [SerializeField]
    internal BossRangedAttack rangedAttack;
    [SerializeField]
    internal BossCharge chargeAttack;
    [SerializeField]
    internal WaveAttack waveAttack;

    [Header("Boss Decision Making")]
    //[SerializeField]
    //internal BossAI bossai;
    public bool verbose = false;
    public bool movement_override = false;
    public float decisionLocked = 0;
    public float roll = 0f;
    public float meleeRange = 1.5f;
    public float waveRange = 9f; //random
    public bool cooldownOverride = false;

    public GameObject facingObject => transform.Find("Facing").gameObject;
    public Transform MeleeAttackPoint => transform.Find("MeleeAttackPoint").gameObject.transform;
    public Transform RangedAttackPoint => transform.Find("RangedAttackPoint").gameObject.transform;


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

        if (Boss.isDead)
        {
            isInvulnerable = true;
            canAct = false;
            animator.SetBool("isDead", true);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
            enabled = false;
        }

        //Stamina Regen
        Boss.StaminaRegen();
        /*
0-70: check if target is in range of melee attack:
            yes: try to do melee combo if enough stamina, otherwise do a single melee attack
            no: try to get in range
 70-90: use a ranged attack on target
90-100: use a wave attack on target
*/
        Vector2 facing = (((target.position - rb.position) * 500).normalized);

        // Flip Sprite render x axis when switching directions
        if (facing.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (facing.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        animator.SetFloat("Horizontal", facing.x);
        animator.SetFloat("Vertical", facing.y);
        animator.SetFloat("Speed", facing.sqrMagnitude);



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
        if(!movement_override) gameObject.GetComponent<Pathfinding.AIPath>().canMove = false;
        if (canAct)
        {
            if (decisionLocked <= 0)
            {
                //Remove once working
                roll = Random.Range(0f, 100f);
                Debug.Log("Boss " + Boss.bossID + " rolled a 1d100: " + roll);
            }
            if (roll <= 40)
            {
                ChargeAttack();
            }
            else if (roll <= 70)
            {
                if ((target.position - rb.position).magnitude < meleeRange)
                {
                    if (Boss.currentStamina >= 50)
                    {
                        Boss.currentStamina = Boss.currentStamina - 50;
                        ComboAttack();
                    }
                    else
                    {

                        MeleeAttack();

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
                if (decisionLocked <= 0) decisionLocked = comboAttack.cooldown;
            }
            else if (roll <= 90)
            {

                RangedAttack();
                if (decisionLocked <= 0) decisionLocked = 1f;
            }
            else //if roll > 90
            {
                if (verbose) Debug.Log("Trying to perform wave attack");
                if (Boss.currentStamina > 10)
                {
                    Boss.currentStamina = Boss.currentStamina - 10;
                    WaveAttack();
                }
                else
                {
                    ;
                    //Debug.Log("Not enough stamina for wave attack");
                }
                if (decisionLocked <= 0) decisionLocked = 0.5f;
            }


        }
        else
        {
            // prevents Boss from attacking consecutively without cooldown
            cooldown -= Time.deltaTime;
            if (cooldown <= 0 || cooldownOverride)
            {
                cooldownOverride = false;
                animator.SetBool("isMeleeAttacking", false);
                canAct = true;
            }
        }
    }

    public void disableCooldown() 
    {
        cooldownOverride = true;
    }

    public void ResetAllBossAnimBools()
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.type is AnimatorControllerParameterType.Bool)
            {
                animator.SetBool(parameter.name, false);
            }
        }
        disableCooldown();
    }
    void MeleeAttack()
    {
        cooldown = 999;
        animator.SetBool("isMeleeAttacking", true);
        canAct = false;
        Debug.Log("Boss Melee Attack");
    }

    void ChargeAttack()
    {
        cooldown = 999;
        Boss.ReduceStamina(chargeAttack.staminaCost);
        chargeAttack.attack();
        canAct = false;
        Debug.Log("Boss Charge Attack");
    }

    void ComboAttack()
    {
        cooldown = 999;
        comboAttack.comboAttack();
        canAct = false;
        Debug.Log("Boss Combo Attack");
    }

    void RangedAttack()
    {
        cooldown = (0.30f);
        rangedAttack.attack();
        canAct = false;
    }

    void WaveAttack()
    {
        cooldown = waveAttack.cooldown;
        waveAttack.waveAttack();
        canAct = false;
        Debug.Log("Boss Wave Attack");
    }

}
