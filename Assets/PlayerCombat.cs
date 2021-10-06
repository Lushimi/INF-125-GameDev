using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
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
        Debug.Log("Dodge");
    }
}
