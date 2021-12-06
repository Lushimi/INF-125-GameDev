using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CutsceneController : MonoBehaviour
{
    public GameEvent cutsceneOver;
    [Header("Debug")]
    public bool verbose = false;

    public int cutsceneState = 0;
    public float timePassed = 0;

    public void MassDisable()
    {
        var entities = FindObjectsOfType(typeof(EntityControl));
        foreach(EntityControl entity in entities)
        {
            entity.Disable();
        }
        if (verbose) Debug.Log("Disabled all entities.");
    }

    public void knockbackAllAroundObject(GameObject center, float radius, float force)
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(center.transform.position, radius);

        // Damage enemies (loop over all enemies in collider array)
        foreach (Collider2D target in hit)
        {
            var obj = target.gameObject;
            var rb =(Rigidbody2D)obj.GetComponent(typeof(Rigidbody2D));
            var direction = (obj.transform.position - center.transform.position).normalized;
            rb.AddForce(new Vector2(direction.x, direction.y)*force, ForceMode2D.Impulse);

        }
    }

    public void MassEnable()
    {
        var entities = FindObjectsOfType(typeof(EntityControl));
        foreach (EntityControl entity in entities)
        {
            entity.Enable();
        }
        if (verbose) Debug.Log("Enabled all entities.");
    }

    public void DisableUI()
    {

    }

    public void EnableUI()
    {

    }

    public void Start()
    {
        MassDisable();
        DisableUI();
    }

   
    public void moveEntity(Rigidbody2D ec, Vector2 moveVector)
    {
        ec.MovePosition(ec.position + moveVector);
    }

    //Continuos actions
    public void FixedUpdate()
    {
        resolveContinuousState(cutsceneState);
    }
    //Advances cutsceneState and performs actions that don't need to be done frame by frame
    public void playCutscene()
    {
        
        cutsceneState += 1;
        timePassed = 0f;
        resolveAtomicState(cutsceneState);
        
    }

    public abstract void resolveContinuousState(int sceneState);


    public abstract void resolveAtomicState(int sceneState);

    public abstract void skip();
}
