using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Fireball : Special
{
    public Transform rangedAttackPoint => transform.parent.Find("RangedAttackPoint");
    public Transform facing => transform.parent.Find("Facing").transform;
    public GameObject fireballPrefab;

    public override void special()
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
