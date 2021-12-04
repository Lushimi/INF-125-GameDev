using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigKnight_AxeThrow : BossBullet
{
    public GameEvent axeDestroyed;

    public override void Start()
    {

        // Changes rigidbody velocity
        rb.velocity = new Vector2(facing.position.x, facing.position.y) * speed;


        //basically copypasted from rotat_e
        gameObject.GetComponent<Transform>().eulerAngles = Vector3.forward * 180;
        float angle = Mathf.Atan2(facing.position.y, facing.position.x) * Mathf.Rad2Deg;
        gameObject.GetComponent<Transform>().eulerAngles = Vector3.forward * angle;
        StartCoroutine(destroyTimer());
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        axeDestroyed.Raise();
    }
}
