using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RangedAttack : MonoBehaviour
{
    public Transform rangedAttackPoint;
    public GameObject bulletPrefab;

    public void attack()
    {
        Shoot();
    }

    void Shoot()
    {
        // shooting logic
        Instantiate(bulletPrefab, rangedAttackPoint.position, rangedAttackPoint.rotation);

    }
}
