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
        Vector2 distance = new Vector2(PlayerController.movementVector.x, PlayerController.movementVector.y).normalized * Speed;
        RaycastHit2D hit = Physics2D.Raycast(transform.parent.GetComponent<Rigidbody2D>().position, new Vector2(PlayerController.movementVector.x, PlayerController.movementVector.y).normalized, distance.magnitude,mask);
        if(hit.collider==null)
        {
            transform.parent.GetComponent<Rigidbody2D>().position += distance;
        } else
        {
            transform.parent.GetComponent<Rigidbody2D>().position += hit.distance*distance/Speed;
        }
        
        
    }
}
