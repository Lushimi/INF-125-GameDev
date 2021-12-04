using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossRangedAttack : MonoBehaviour
{
    public Animator animator;
    public Transform rangedAttackPoint => transform.Find("RangedAttackPoint");
    public Transform facing => transform.Find("Facing");
    public GameObject projectilePrefab;

    [Header("Game Events")]
    [SerializeField]
    internal GameEvent ShootSFX;

    public void attack()
    {
        StartThrowAxe();
    }

    public void Shoot()
    {
        // shooting logic
        Transform bulletTransform=( Instantiate(projectilePrefab, rangedAttackPoint.position, rangedAttackPoint.rotation) ).transform;
        bulletTransform.GetComponentInChildren<BossBullet>().Setup(facing);
    }

    public void StartThrowAxe()
    {
        animator.SetBool("isThrowingAxe", true);
    }

    public void CreateAxe()
    {
        GameObject spinningAxe = Instantiate(projectilePrefab, rangedAttackPoint.position, rangedAttackPoint.rotation);
        spinningAxe.GetComponentInChildren<BossBullet>().Setup(facing);
    }

    public void FinishAxeThrow()
    {
        animator.SetBool("isThrowingAxe", false);
    }

    public void PlayShootSFX()
    {
        ShootSFX.Raise();
    }
}
