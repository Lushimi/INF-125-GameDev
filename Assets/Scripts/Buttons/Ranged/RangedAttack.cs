using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RangedAttack : MonoBehaviour
{
    public Transform rangedAttackPoint => transform.parent.Find("RangedAttackPoint");
    public Transform facing => transform.parent.Find("Facing").transform;
    public Animator animator => transform.parent.GetComponent<PlayerControl>().animator;
    public GameObject bulletPrefab;

    public int rangedAttackType;
    public float cooldown = 0.75f;

    public void attack()
    {
        Shoot();
    }

    void Shoot()
    {
        // shooting logic
        Transform bulletTransform=(Instantiate(bulletPrefab, rangedAttackPoint.position, rangedAttackPoint.rotation)).transform;
        bulletTransform.GetComponent<Bullet>().Setup(facing);
        animator.SetBool("isRangedAttacking", true);

    }

    public void setRangedAttackData(RangedAttackData rangedAttackData)
    {
        rangedAttackType = rangedAttackData.rangedAttackType;
        cooldown = rangedAttackData.cooldown;

    }
}
