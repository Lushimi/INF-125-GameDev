using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //player's scriptable object data, stored in the asset folder
    [SerializeField]
    internal PlayerData Player;
    [SerializeField]
    internal Rigidbody2D rb;
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
    internal Animator animator;
    [SerializeField]
    internal float attackRate = 0.25f;
    [SerializeField]
    internal float attackCounter = 0.25f;
    
    public Vector3 movementVector;

    public IEnumerator disableActions(float time)
    {
        Player.canAct = false;

        yield return new WaitForSeconds(time);

        Player.canAct = true;
    }

    private void Awake()
    {
        Player.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Player.StaminaRegen();
        if (Player.canAct)
        {

            //Movement control
            movementVector.x = Input.GetAxis("Horizontal");
            movementVector.y = Input.GetAxis("Vertical");
            movementVector.z = 0;

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
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                animator.SetBool("isAttacking", false);
                Player.canAct = true;
            }
        }
    
    }





    // Player Melee Attack
    void MeleeAttack()
    {
        attackCounter = attackRate;
        meleeAttack.attack();
        Player.canAct = false;
    }


    // Player Ranged Attack
    void RangedAttack()
    {
        rangedAttack.attack();
    }


    // Player Dodge Attack
    void Dodge()
    {
        // Play dodge animationa
        // Move character in direction of dodge
        if (Player.currentStamina > 0) {
            dodgeMove.PerformDodge();
            Player.ReduceStamina(dodgeMove.staminaCost);
        }

        Debug.Log("Dodge");
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
        parryMove.parry();
        Debug.Log("Parry");
    }
}
