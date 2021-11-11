using System.Collections;
using System;
using UnityEngine;

public class PlayerControl : EntityControl
{
    [Header("Player")]
    //player data
    [SerializeField]
    internal PlayerData Player;
    [SerializeField]
    internal Camera cam;
    public float invincibiltyTimeOnHit;

    [Header("Loadout")]
    [SerializeField]
    internal LoadoutManager loadout;
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

    public GameObject facingObject => transform.Find("Facing").gameObject;
    public Transform MeleeAttackPoint => transform.Find("MeleeAttackPoint").gameObject.transform;
    public Transform RangedAttackPoint => transform.Find("RangedAttackPoint").gameObject.transform;

    public int bossesDefeated = 0;

    private void Awake()
    {
        Player.Reset();
        Debug.Log(MeleeAttackPoint);
    }

    // Update is called once per frame
    void Update()
    {
        Player.StaminaRegen();

        if (canAct)
        {

            //Movement control
            movementVector.x = Input.GetAxisRaw("Horizontal");
            movementVector.y = Input.GetAxisRaw("Vertical");
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
                orientationVector = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
                Vector2 orientationVector2D = new Vector2(orientationVector.x, orientationVector.y);
                Vector2 facing = (((orientationVector2D - rb.position) * 500).normalized);

                //update melee/ranged attack points
                try
                {
                    MeleeAttackPoint.position = rb.position + meleeAttack.attackRange * facing;
                    RangedAttackPoint.position = rb.position + 1f * facing;
                }
                catch (Exception e)
                {
                   // Debug.LogError(e);
                }

                //set the facing child object to facing
                facingObject.transform.position = facing;

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
            //this "L" button is just for testing the loadout
            else if (Input.GetKeyDown(KeyCode.L))
            {
                ChangeLoadout();
                dodgeMove = dodgeMove == null ? loadout.DodgeList[0] : dodgeMove;
                meleeAttack = meleeAttack == null ? loadout.MeleeList[0] : meleeAttack;
                rangedAttack = rangedAttack == null ? loadout.RangedList[0] : rangedAttack;
                specialAttack = specialAttack == null ? loadout.SpecialList[0] : specialAttack;
                parryMove = parryMove == null ? loadout.ParryList[0] : parryMove;
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

    public void movePlayer(Vector3 moveVector)
    {
        transform.position += moveVector;
    }

    public void invulnOnHit()
    {
        StartCoroutine(ActivateInvincibility(invincibiltyTimeOnHit));
    }

    public IEnumerator ActivateInvincibility(float invulnTime)
    {
        isInvulnerable = true;
        for (float i = 0; i < invulnTime; i += (invulnTime/75) )
        {
            yield return new WaitForSeconds(invulnTime/75);
        }
        isInvulnerable = false;
    }

    //saves the game for player
    void SaveGame()
    {
        SaveData saveData =
    }

    //loads the game for player
    void LoadGame()
    {

    }

    // Player Melee Attack
    void MeleeAttack()
    {
        cooldown = meleeAttack.cooldown;
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

    void ChangeLoadout()
    {
        loadout.checkList();
    }

}
