using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour
{

    //types of dodges
    public enum DodgeType
    {
        Roll,
        Blink,
        Dash,
        Backflip
    }

    //Player speed
    public float speed=5f;
    //Current dodge type
    public DodgeType dodge = DodgeType.Roll;
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

    
    private IEnumerator iDodge(float startup, float invuln, float endLag, float speed, Vector3 movementVector)
    {
        //Dodge with iframe
        //startup - the time after the dodge starts but before the invuln takes effect
        //invuln - duration of iframes
        //endlag - the time where the player can't act even though they are no longer in iframes
        //speed - how fast the character moves during the dodge
        //movementVector - the direction of the dodge


        //Disable any other actions
        StartCoroutine(disableActions(startup + invuln + endLag));
       
        //startup part of dodge
        float startupDeltaTime = startup / 75; //literal arbitrary, could use anything else
        for (float i = 0; i < startup; i += startupDeltaTime)
        {
            gameObject.transform.position += movementVector.normalized * (speed*startup/(startup+invuln)) * startupDeltaTime;
            yield return new WaitForSeconds(startupDeltaTime);
        }
       
        //iframe part of dodge
        float invulnDeltaTime = invuln / 75; //literal is arbitrary, could use anything else
        isInvulnerable = true;
        for (float i = 0; i < invuln; i += invulnDeltaTime)
        {
            gameObject.transform.position += movementVector.normalized * (speed * invuln / (startup + invuln)) * invulnDeltaTime;
            yield return new WaitForSeconds(invulnDeltaTime);
        }

        isInvulnerable = false;
    }

    private IEnumerator disableActions(float time)
    {
        canAct = false;

        yield return new WaitForSeconds(time);

        canAct = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Stamina regen
        if(stamina<100)
        {
            stamina += Math.Min(100 - stamina, Time.deltaTime * stamina_per_second);
        }

        
        if(canAct)
        {
            //Movement control
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 tempVect = new Vector3(h, v, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;

            gameObject.transform.position += tempVect;

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
        // Play an attack animation
        // Detect enemies in range of attack
        // Damage them

        Debug.Log("Melee Attack");
    }


    // Player Ranged Attack
    void RangedAttack()
    {
        // Play an ranged attack animation
        // Detect enemies in range of attack
        // Damage them

        Debug.Log("Ranged Attack");
    }


    // Player Dodge Attack
    void Dodge()
    {
        // Play dodge animation
        // Move character in direction of dodge
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(h, v, 0);
        
        //Different dodge upgrade support
        switch (dodge)
        {
            case (DodgeType.Roll):
            {       //Roll: many iframes, slower, significant end lag, low stamina cost
                    float rollcost = 35f;
                    float startup = 0.2f;
                    float invuln = 0.4f;
                    float endLag = 0.4f;
                    //1.0
                    float dodgespeed = 2f * speed;
                    if (stamina>rollcost)
                    {
                        stamina -= rollcost;
                        if (!isInvulnerable)
                        {
                            StartCoroutine(iDodge(startup, invuln, endLag, dodgespeed, movementVector));
                        }
                    } else
                    {
                        Debug.Log("Not enough stamina :(");
                    }
                    
                    break;
            }
            case (DodgeType.Blink):
            {
                    //Blink: no iframes, instant, no end lag, extreme stamina cost
                    float rollcost = 90f;
                    float distance = 1.5f * speed;
                    if (stamina > rollcost)
                    {
                        stamina -= rollcost;
                        gameObject.transform.position += movementVector.normalized * distance;
                    }
                    else
                    {
                        Debug.Log("Not enough stamina :(");
                    }
                    break;
            }
            case (DodgeType.Dash):
            {
                    //Dash: few iframes, fast, little end lag, moderate stamina cost
                    float rollcost = 65f;
                    float startup = 0.05f;
                    float invuln = 0.25f;
                    float endLag = 0.1f;
                    //0.4
                    float dodgespeed = 3.5f * speed;
                    if (stamina > rollcost)
                    {
                        stamina -= rollcost;
                        if (!isInvulnerable)
                        {
                            StartCoroutine(iDodge(startup, invuln, endLag, dodgespeed, movementVector));
                        }
                    }
                    else
                    {
                        Debug.Log("Not enough stamina :(");
                    }

                    break;
            }
            case (DodgeType.Backflip):
                {
                    //Backstep: opposite direction, a lot of iframes, slowish but long distance, significant end lag, high stamina cost
                    float rollcost = 75f;
                    float startup = 0.2f;
                    float invuln = 1.2f;
                    float endLag = 0.6f;
                    //2
                    float dodgespeed = 1.5f * speed;
                    if (stamina > rollcost)
                    {
                        stamina -= rollcost;
                        if (!isInvulnerable)
                        {
                            StartCoroutine(iDodge(startup, invuln, endLag, speed, movementVector*-1));
                        }
                    }
                    else
                    {
                        Debug.Log("Not enough stamina :(");
                    }

                    break;
                }
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
