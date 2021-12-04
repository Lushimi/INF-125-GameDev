using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : BossBullet
{


    // Start is called before the first frame update
    public override void Start()
    {

        // Changes rigidbody velocity
        rb.velocity = new Vector2(facing.position.x, facing.position.y) * speed;


        //basically copypasted from rotat_e
        gameObject.GetComponent<Transform>().eulerAngles = Vector3.forward * -180;
        float angle = Mathf.Atan2(facing.position.y, facing.position.x) * Mathf.Rad2Deg;
        gameObject.GetComponent<Transform>().eulerAngles = Vector3.forward * angle * -90;
        StartCoroutine(destroyTimer());
    }


    public void Wave_DestroySelf()
    {
        Destroy(gameObject);
    }


    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Get info for the enemies we hit

        //Add a case for colliding into world (trees, boundaries)
        EntityData hit = hitInfo.GetComponent<EntityData>();
        // If player was hit
        if (hit is PlayerData)
        {
            // deal damage to enemy
            hit.TakeDamage(damage, this.gameObject);
            Destroy(gameObject);
        }
        else if (!(hit is BossData))
        {
            Destroy(gameObject);
        }


    }
}
