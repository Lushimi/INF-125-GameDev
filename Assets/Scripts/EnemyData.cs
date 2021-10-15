using System;
using UnityEngine;

[Serializable]
public class EnemyData : MonoBehaviour
{
    //default values here
    [SerializeField]
    private FloatVariable maxHP;

    // stats here
    public float speed = 5f;
    public float currentHealth = 0;

    //Flag for checking if on-hit effects should apply
    public bool isInvulnerable = false;
    //flag for checking if player can act
    public bool canAct = true;

    // Start is called before the first frame update
    void Reset()
    {
        currentHealth = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Play hurt animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        canAct = false;
        Debug.Log("Enemy died!");

        // Die Animation
    }

}
