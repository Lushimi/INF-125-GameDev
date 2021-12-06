using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : BossBullet
{


    // Start is called before the first frame update
    public override void Start()
    {
        // Changes rigidbody velocity
        rb.velocity = new Vector2(facing.position.x, facing.position.y) *  speed;
        StartCoroutine(destroyTimer());
    }

    public void Update()
    {
        var targetScale = transform.localScale * 2;
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
    }

    public void Wave_DestroySelf()
    {
        Destroy(gameObject);
    }

}
