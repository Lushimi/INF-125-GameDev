using System.Collections;
using UnityEngine;

public class PlayerControl : EntityControl
{
    //player data
    [SerializeField]
    internal PlayerData Player;

    [SerializeField]
    internal Dodge dodgeMove;
    [SerializeField]
    internal MeleeAttack meleeAttack;
    [SerializeField]
    internal RangedAttack rangedAttack;
    [SerializeField]
    internal Special specialAttack;
    [SerializeField]
    internal Parry parryMove;
    [SerializeField]


    private void Awake()
    {
        Player.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Player.StaminaRegen();
        if (canAct)
        {

            //Movement control
            movementVector.x = Input.GetAxis("Horizontal");
            movementVector.y = Input.GetAxis("Vertical");
            movementVector.z = 0;

            //sets player orientation = to mouse position
            orientationVector = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            animator.SetFloat("Horizontal", movementVector.x);
            animator.SetFloat("Vertical", movementVector.y);
            animator.SetFloat("Speed", movementVector.sqrMagnitude);

            rb.MovePosition(rb.position + new Vector2(movementVector.x, movementVector.y).normalized * Player.speed * Time.fixedDeltaTime);


            //Input processing
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                MeleeAttack();
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                RangedAttack();
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Dodge();
            }
            else if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space))
            {
                Assist();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Special();
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                Parry();
            }

        }
        else
        {
            // prevents Player from attacking consecutively without cooldown
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                animator.SetBool("isAttacking", false);
                canAct = true;
            }
        }
    
    }





    // Player Melee Attack
    void MeleeAttack()
    {
        cooldown = meleeAttack.attackRate;
        meleeAttack.attack();
        canAct = false;
        Debug.Log("MeleeAttack");
    }


    // Player Ranged Attack
    void RangedAttack()
    {
        rangedAttack.attack();
        Debug.Log("RangedAttack");
    }


    // Player Dodge Attack
    void Dodge()
    {
        // Play dodge animationa
        // Move character in direction of dodge
        if (Player.currentStamina > 0) {
            cooldown = (dodgeMove.cooldown);
            dodgeMove.PerformDodge();
            Player.ReduceStamina(dodgeMove.staminaCost);
            canAct = false;
            Debug.Log("Dodge");
        }
    }

    //Player Assist Move
    void Assist()
    {
        //Assist animation occurs
        //Assisting character joins screen
        //leave this for later
        Debug.Log("Assist");
    }

    //Player Special
    void Special()
    {
        //Special animation occurs
        //Special ability appears and does action
        specialAttack.special();
        Debug.Log("Special");
    }

    //Player Parry
    void Parry()
    {
        //Parry animation occurs
        //Frame of invulnerability with ending lag
        cooldown = (parryMove.cooldown);
        parryMove.parry();
        canAct = false;
        Debug.Log("Parry");
    }
}
