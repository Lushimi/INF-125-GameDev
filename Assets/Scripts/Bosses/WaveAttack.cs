using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//Wave attack - wave attack from boss, small range but large hitbox
public class WaveAttack : MonoBehaviour
{
    public Transform wavePoint;
    public Transform facing;
    public GameObject wavePrefab;

    public float startup = 0.1f;
    public float cooldown => startup;

    public void waveAttack()
    {
        Wave();
    }

    void Wave()
    {
        // Wave logic
        //Instantiate(wavePrefab, wavePoint.position, wavePoint.rotation);
        Transform waveTransform = (Instantiate(wavePrefab, wavePoint.position, wavePoint.rotation)).transform;
        waveTransform.GetComponent<Wave>().Setup(facing);
        //Destroy(gameObject);
    }
}


