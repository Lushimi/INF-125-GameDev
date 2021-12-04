using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assist_BIGKNIGHT : Assist
{
    public override void spawn() 
    {
        if (ShouldSpawn()) 
        {
            boss = Instantiate(bossPrefab, transform.position, transform.rotation);
            Destroy(boss, 30.0f);
            cooldown = 9000;
        }
        else 
        {
            Debug.Log("BIGKNIGHT is on cooldown");
        }
    }
}
