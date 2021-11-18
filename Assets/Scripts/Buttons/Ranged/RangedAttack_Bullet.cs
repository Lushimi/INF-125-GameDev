using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack_Bullet : RangedAttack
{
    public Transform rangedAttackPoint => transform.parent.Find("RangedAttackPoint");
    public Transform facing => transform.parent.Find("Facing").transform;

    public GameObject bulletPrefab;
    

    public override void attack()
    {
        Shoot();
    }

    public void Shoot()
    {
        // shooting logic
        Transform bulletTransform = (Instantiate(bulletPrefab, rangedAttackPoint.position, rangedAttackPoint.rotation)).transform;
        bulletTransform.GetComponent<Bullet>().Setup(facing);
        animator.SetBool("isRangedAttacking", true);

    }
}
