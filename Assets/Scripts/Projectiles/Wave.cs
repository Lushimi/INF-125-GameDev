using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int damage;
    public Transform facing;
    public float lifespan = 3.1f;

    public void Setup(Transform facing)
    {
        //Debug.Log("RUNNING SETUP");
        this.facing = facing;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("RUNNING START");
        rb.velocity = new Vector2(facing.position.x, facing.position.y) * speed;

        gameObject.GetComponent<Transform>().eulerAngles = Vector3.forward * 90;
        float angle = Mathf.Atan2(facing.position.y, facing.position.x) * Mathf.Rad2Deg;
        gameObject.GetComponent<Transform>().eulerAngles = Vector3.forward * angle;
        // Destroy(gameObject, lifespan);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Get info for the enemies we hit

        //Add a case for colliding into world (trees, boundaries)
        PlayerData player = hitInfo.GetComponent<PlayerData>();
        // If player was hit
        if (player != null)
        {
            // deal damage to enemy
            player.TakeDamage(damage, this.gameObject);
        }

        // destroy bullet
        if (!(hitInfo.GetComponent<EntityData>() is BossData))
            Destroy(gameObject);
    }

}
