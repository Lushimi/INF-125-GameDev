using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack_Arrow : RangedAttack
{
    public Transform rangedAttackPoint => transform.parent.Find("RangedAttackPoint");
    public Transform facing => transform.parent.Find("Facing").transform;

    public GameObject arrowPrefab;
    

    public override void attack()
    {
        Shoot();
    }

    public void Shoot()
    {
        // shooting logic
        Transform arrowTransform = (Instantiate(arrowPrefab, rangedAttackPoint.position, rangedAttackPoint.rotation)).transform;
        arrowTransform.GetComponent<Arrow>().Setup(facing);
        animator.SetBool("isRangedAttacking", true);

    }
}
