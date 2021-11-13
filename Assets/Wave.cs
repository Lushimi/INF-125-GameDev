using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Trim bullet
public class Wave : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public int damage = 10;
    public Transform facing;
    

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
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Debug.Log("Wave collision");
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
        Destroy(gameObject);
    }

}
