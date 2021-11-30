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
    public void spawn()
    {
        if (ShouldSpawn()) 
        {
            boss = Instantiate(bossPrefab, transform.position, transform.rotation);
            setCloneProperties();
            Destroy(boss, 30.0f);
            cooldown = 30;
        }
    }

    private bool ShouldSpawn()
    {
        return cooldown <= 0;
    }

    void setCloneProperties() 
    {
        boss.layer = LayerMask.NameToLayer("Player");
        boss.GetComponent<BossControl>().target = GameObject.Find("Boss").GetComponent<Rigidbody2D>();
        boss.GetComponent<BossMeleeAttack>().enemyLayers = LayerMask.GetMask("Enemies");
        boss.GetComponent<BossCharge>().enemyLayers = LayerMask.GetMask("Enemies");
        boss.GetComponent<ComboAttack>().enemyLayers = LayerMask.GetMask("Enemies"); 
    }
}
