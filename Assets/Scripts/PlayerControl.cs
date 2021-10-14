using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //player's scriptable object data, stored in the asset folder
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
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            movementVector = new Vector3(h, v, 0);
            movementVector = movementVector.normalized * Player.speed * Time.deltaTime;

            gameObject.transform.position += movementVector;

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


    }

    // Player Melee Attack
    void MeleeAttack()
    {
        meleeAttack.attack();
        Debug.Log("Melee Attack");
    }


    // Player Ranged Attack
    void RangedAttack()
    {
        rangedAttack.attack();
        Debug.Log("Ranged Attack");
    }


    // Player Dodge Attack
    void Dodge()
    {
        // Play dodge animation
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
