using System.Collections;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int damage = 30;
    public float speed = 10f;
    public float liveTime = 5f;
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


        //basically copypasted from rotat_e
        gameObject.GetComponent<Transform>().eulerAngles = Vector3.forward * 90;
        float angle = Mathf.Atan2(facing.position.y, facing.position.x) * Mathf.Rad2Deg;
        gameObject.GetComponent<Transform>().eulerAngles = Vector3.forward * angle;
        StartCoroutine(destroyTimer());
    }


    private IEnumerator destroyTimer()
    { 
        yield return new WaitForSecondsRealtime(liveTime);
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Get info for the enemies we hit
        BossData enemy = hitInfo.GetComponent<BossData>();
        // If an enemy was hit
        if (enemy != null && enemy.gameObject.tag != "Ally")
        {
            // deal damage to enemy
            enemy.TakeDamage(damage);
            // destroy fireball
            Destroy(gameObject);
        }

        Debug.Log(hitInfo.gameObject.layer);
        if (!(hitInfo.gameObject.layer == (LayerMask)11) && !(hitInfo.gameObject.layer == (LayerMask)12) && !(hitInfo.gameObject.layer == (LayerMask)10))
        {
            if (!(hitInfo.GetComponent<EntityData>() is PlayerData))
                Destroy(gameObject);
        }
    }
}
