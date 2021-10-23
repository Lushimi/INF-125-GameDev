using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RangedAttack : MonoBehaviour
{
    public Transform rangedAttackPoint;
    public Transform facing;
    public GameObject bulletPrefab;

    public void attack()
    {
        Shoot();
    }

    void Shoot()
    {
        // shooting logic
        Transform bulletTransform=(Instantiate(bulletPrefab, rangedAttackPoint.position, rangedAttackPoint.rotation)).transform;
        bulletTransform.GetComponent<Bullet>().Setup(facing);

    }
}
