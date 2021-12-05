using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{

    public float speed;
    public int damage;
    public Rigidbody2D rb;
    public Transform facing;
    public float liveTime;

    public void Setup(Transform facing)
    {
        this.facing = facing;
    }

    // Start is called before the first frame update
    public virtual void Start()
    {

        // Changes rigidbody velocity
        rb.velocity = new Vector2(facing.position.x, facing.position.y) * speed;


        //basically copypasted from rotat_e
        gameObject.GetComponent<Transform>().eulerAngles = Vector3.forward * 90;
        float angle = Mathf.Atan2(facing.position.y, facing.position.x) * Mathf.Rad2Deg;
        gameObject.GetComponent<Transform>().eulerAngles = Vector3.forward * angle;
        StartCoroutine(destroyTimer());
    }


    internal IEnumerator destroyTimer()
    {
        yield return new WaitForSecondsRealtime(liveTime);
        Destroy(gameObject);
    }


    public virtual void OnTriggerEnter2D(Collider2D hitInfo)
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
        else if (hit is BossData)
        {
            if (gameObject.layer == (LayerMask)13)
            {
                if (!(hitInfo.gameObject.layer == (LayerMask)10) && !(hitInfo.gameObject.layer == (LayerMask)12) && !(hitInfo.gameObject.layer == (LayerMask)13))
                    Destroy(gameObject);
            }
            else
            {
                if (!(hitInfo.gameObject.layer == (LayerMask)12) && !(hitInfo.gameObject.layer == (LayerMask)13))
                    Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public virtual void OnDestroy()
    {
        Destroy(transform.parent.gameObject);
    }

}
