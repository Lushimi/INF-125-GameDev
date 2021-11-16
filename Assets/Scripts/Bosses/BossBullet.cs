using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{

    public float speed = 10f;
    public int damage = 1;
    public Rigidbody2D rb;
    public Transform facing;

    public void Setup(Transform facing)
    {
        this.facing = facing;
    }

    // Start is called before the first frame update
    void Start()
    {

        // Changes rigidbody velocity
        rb.velocity = new Vector2(facing.position.x,facing.position.y) * speed;

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Get info for the enemies we hit
        PlayerData enemy = hitInfo.GetComponent<PlayerData>();
        // If an enemy was hit
        if (enemy != null)
        {
            // deal damage to enemy
            enemy.TakeDamage(damage);
        }
        
        // destroy bullet
        Destroy(gameObject);
    }



}


