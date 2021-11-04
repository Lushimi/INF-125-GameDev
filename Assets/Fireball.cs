using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int damage = 30;
    public float speed = 10f;
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
        rb.velocity = new Vector2(facing.position.x, facing.position.y) * speed;

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

        // destroy fireball
        Destroy(gameObject);
    }
}
