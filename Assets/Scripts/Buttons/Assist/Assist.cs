using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assist : Button
{
    public float cooldown = 0;
    public GameObject bossPrefab;
    
    public GameObject boss;

    public void Update() 
    {
        if (cooldown != 0) {
            cooldown -= Time.deltaTime;
        }
    }
    public virtual void spawn() {}

    public bool ShouldSpawn()
    {
        return cooldown <= 0;
    }
}
