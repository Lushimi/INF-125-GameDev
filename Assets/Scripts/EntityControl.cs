using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityControl : MonoBehaviour
{
    [Header("Entity")]
    [SerializeField]
    internal Rigidbody2D rb;
    [SerializeField]
    internal Animator animator;

    [Header("Cooldown and Invlun")]
    [SerializeField]
    internal float cooldown;
    //Flag for checking if on-hit effects should apply
    public bool isInvulnerable = false;
    //flag for checking if player can act
    public float invincibiltyTimeOnHit;
    public bool canAct = false;
    public bool isDisabled = false;
    public bool isDead = false;

    [Header("Vectors")]
    public Vector3 movementVector;
    public Vector3 orientationVector;


    public void invulnOnHit()
    {
        StartCoroutine(ActivateInvincibility(invincibiltyTimeOnHit));
    }

    //this also stuns the mob by putting the canAct to false
    public IEnumerator ActivateInvincibility(float invulnTime)
    {
        Debug.Log("GotInvuln?");
        isInvulnerable = true;
        if (canAct)
        {
            canAct = false;
            for (float i = 0; i < invulnTime; i += (invulnTime))
            {
                yield return new WaitForSeconds(invulnTime);
                isInvulnerable = false;
            }
            canAct = true;
        }
        else
        {
            for (float i = 0; i < invulnTime; i += (invulnTime))
            {
                yield return new WaitForSeconds(invulnTime);
                isInvulnerable = false;
            }

        }

    }

    public void Disable()
    {
        cooldown = 999;
        isDisabled = true;
        canAct = false;
    }

    public void Enable()
    {
        cooldown = 0;
        isDisabled = false;
    }
    
}
