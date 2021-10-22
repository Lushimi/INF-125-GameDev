using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public int damage = 40;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        // Changes rigidbody velocity
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Get info for the enemies we hit
        BossData enemy = hitInfo.GetComponent<BossData>();
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
