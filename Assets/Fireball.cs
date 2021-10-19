using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int damage = 30;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(gameObject);
        BossData boss = collision.GetComponent<BossData>();

        if (boss != null)
        {
            boss.TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
