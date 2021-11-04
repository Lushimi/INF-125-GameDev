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
    [SerializeField]
    internal float cooldown;

    //Flag for checking if on-hit effects should apply
    public bool isInvulnerable = false;
    //flag for checking if player can act
    public bool canAct = true;

    public Vector3 movementVector;
    public Vector3 orientationVector;
}
