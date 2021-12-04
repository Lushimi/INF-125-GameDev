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
    public float coneSize = 3.5f;

    public void waveAttack()
    {
        StartWave();
    }

    public void StartWave()
    {
        animator.SetBool("isWaveAttacking", true);
    }


    void Wave()
    {
        // Wave logic
        //Instantiate(wavePrefab, wavePoint.position, wavePoint.rotation);
        //https://forum.unity.com/threads/cone-shaped-bullet-spread.414893/
        /*float xSpread = UnityEngine.Random.Range(-1, 1);
        float ySpread = UnityEngine.Random.Range(-1, 1);
        Vector3 spread = new Vector3(xSpread, ySpread, 0.0f).normalized * coneSize;
        Quaternion rotation = Quaternion.Euler(spread) * wavePoint.rotation;*/

        Transform waveTransform = (Instantiate(wavePrefab, wavePoint.position, wavePoint.rotation)).transform;
        waveTransform.GetComponentInChildren<Wave>().Setup(facing);
        //Destroy(gameObject);
    }

    public void FinishWave()
    {
        animator.SetBool("isWaveAttacking", false);
    }


}
