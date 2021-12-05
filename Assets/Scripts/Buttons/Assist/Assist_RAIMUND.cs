using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Assist_RAIMUND : Assist
{
    public override void spawn() 
    {
        if (ShouldSpawn()) 
        {
            boss = Instantiate(bossPrefab, transform.position, transform.rotation);
            boss.GetComponent<AIDestinationSetter>().target = GameObject.Find("Boss").GetComponent<Transform>();
            boss.GetComponent<BossControl>().target = GameObject.Find("Boss").GetComponent<Rigidbody2D>();
            Destroy(boss, 5.0f);
            cooldown = 30;
        }
        else 
        {
            Debug.Log("RAIMUND is on cooldown");
        }
    }
}
