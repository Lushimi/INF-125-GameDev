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
    internal SpecialFireball specialAttack;
    [SerializeField]
    internal Parry parryMove;
    [SerializeField]
    internal Camera cam;
    

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

            // Flip Sprite render x axis when switching directions
            if (Input.GetAxis("Horizontal") > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            //sets player orientation = to mouse position
            if (Input.mousePosition.x >= 0 && Input.mousePosition.y >= 0 && Input.mousePosition.x <= Screen.width && Input.mousePosition.y <= Screen.height)
            {
                Vector3 orientationVector = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
                Vector2 orientationVector2D = new Vector2(orientationVector.x, orientationVector.y);
                Vector2 facing = (((orientationVector2D - rb.position) * 500).normalized);

                meleeAttack.attackPoint.position = rb.position + meleeAttack.attackRange * facing; 
                rangedAttack.rangedAttackPoint.position = rb.position + 1f * facing;
                
                //set the facing child object to facing
                GameObject child = gameObject.transform.Find("Facing").gameObject;
                child.GetComponent<Transform>().position = facing;

            }


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
