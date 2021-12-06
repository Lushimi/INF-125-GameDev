using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Wave attack - wave attack from boss, small range but large hitbox
//Trim bullet
//Bullet range after 0.01f doesn't get any smaller (about half the screen)

public class WaveAttack : MonoBehaviour
{
    public Animator animator;
    public Transform wavePoint => transform.Find("RangedAttackPoint");
    public Transform facing => transform.Find("Facing");
    public GameObject wavePrefab;

    public float startup = 0.1f;
    public float cooldown = 0.5f;

    public void waveAttack()
    {
        StartWave();
    }

    public void StartWave()
    {
        animator.SetBool("isWaveAttacking", true);
    }


    public void Wave()
    {
        Vector3 tempTransform = Vector3.forward;
        float angle = Mathf.Atan2(facing.transform.position.y, facing.transform.position.x) * Mathf.Rad2Deg;
        tempTransform = Vector3.forward * (angle + 270);

        BossBullet bullet = Instantiate(wavePrefab, wavePoint.position, Quaternion.Euler(tempTransform.x, tempTransform.y, tempTransform.z)).GetComponent<BossBullet>();
        bullet.Setup(facing);
    }

    public void FinishWave()
    {
        animator.SetBool("isWaveAttacking", false);
    }


}
