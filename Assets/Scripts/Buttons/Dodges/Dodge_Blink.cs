using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge_Blink : Dodge
{
    private void Reset()
    {
        staminaCost = 90f;
        dodgeSpeedMultiplier = 1f;
    }

    void Start()
    {
        Reset();
    }

    public override void PerformDodge() 
    {
        LayerMask mask = LayerMask.GetMask("Level Barrier");
        Vector2 distance = new Vector2(GetComponent<PlayerControl>().movementVector.x, GetComponent<PlayerControl>().movementVector.y).normalized * Speed;
        RaycastHit2D hit = Physics2D.Raycast(gameObject.GetComponent<Rigidbody2D>().position, new Vector2(GetComponent<PlayerControl>().movementVector.x, GetComponent<PlayerControl>().movementVector.y).normalized, distance.magnitude,mask);
        if(hit.collider==null)
        {
            gameObject.GetComponent<Rigidbody2D>().position += distance;
        } else
        {
            gameObject.GetComponent<Rigidbody2D>().position += hit.distance*distance/Speed;
        }
        
        
    }
}
