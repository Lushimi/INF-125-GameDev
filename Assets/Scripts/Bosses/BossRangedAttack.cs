using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossRangedAttack : MonoBehaviour
{
    public Transform rangedAttackPoint => transform.Find("RangedAttackPoint");
    public Transform facing => transform.Find("Facing");
    public GameObject bulletPrefab;

    public void attack()
    {
        Shoot();
    }

    public void Shoot()
    {
        // shooting logic
        Transform bulletTransform=(Instantiate(bulletPrefab, rangedAttackPoint.position, rangedAttackPoint.rotation)).transform;
        bulletTransform.GetComponent<BossBullet>().Setup(facing);

    }
}
