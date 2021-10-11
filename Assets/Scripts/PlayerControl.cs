using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour
{
    //Player speed
    public float speed = 5f;
    //Current dodge type
    public Dodge dodge;
    //Current melee attack type
    public Attack meleeAttack;
    //Current ranged attack type
    public Attack rangedAttack;
    //Current stamina
    public float stamina = 100;
    //Stamina regen rate
    public float stamina_per_second = 3;
    //Current health
    public float health = 100;
    //Flag for checking if on-hit effects should apply
    public bool isInvulnerable = false;
    //Flag for checking if the character is not animation locked
    private bool canAct = true;
    public Vector3 movementVector;

    public IEnumerator disableActions(float time)
    {
        canAct = false;

        yield return new WaitForSeconds(time);

        canAct = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Stamina regen
        if (stamina < 100)
        {
            stamina += Math.Min(100 - stamina, Time.deltaTime * stamina_per_second);
        }


        if (canAct)
        {
            //Movement control
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            movementVector = new Vector3(h, v, 0);
            movementVector = movementVector.normalized * speed * Time.deltaTime;

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
            else if (Input.GetKeyDown(KeyCode.F))
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
        if (stamina > 0 && stamina >= dodge.staminaCost) {
            dodge.dodge();
            stamina -= dodge.staminaCost;
        }

        Debug.Log("Dodge");
    }

    //Player Assist Move
    void Assist()
    {
        //Assist animation occurs
        //Assisting character joins screen
        Debug.Log("Assist");
    }

    //Player Special
    void Special()
    {
        //Special animation occurs
        //Special ability appears and does action
        Debug.Log("Special");
    }

    //Player Parry
    void Parry()
    {
        //Parry animation occurs
        //Frame of invulnerability with ending lag
        Debug.Log("Parry");
    }
}
