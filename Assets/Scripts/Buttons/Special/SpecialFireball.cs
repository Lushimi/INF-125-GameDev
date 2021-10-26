using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpecialFireball : MonoBehaviour
{
    public Transform rangedAttackPoint;
    public Transform facing;
    public GameObject fireballPrefab;

    public void special()
    {
        Shoot();
    }

    void Shoot()
    {
        // shooting logic
        Transform fireballTransform = (Instantiate(fireballPrefab, rangedAttackPoint.position, rangedAttackPoint.rotation)).transform;
        fireballTransform.GetComponent<Fireball>().Setup(facing);

    }
}
