using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpecialFireball : MonoBehaviour
{
    public Transform rangedAttackPoint => transform.parent.Find("RangedAttackPoint");
    public Transform facing => transform.parent.Find("Facing").transform;
    public GameObject fireballPrefab;

    public int specialType;

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

    public void setSpecialData(SpecialFireballData specialdata)
    {
        specialType = specialdata.specialType;
    }
}
