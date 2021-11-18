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
    public bool canAct = true;
    public float invincibiltyTimeOnHit;

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
        isInvulnerable = true;
        canAct = false;
        for (float i = 0; i < invulnTime; i += (invulnTime / 75))
        {
            yield return new WaitForSeconds(invulnTime / 75);
        }
        canAct = true;
        isInvulnerable = false;
    }
}
