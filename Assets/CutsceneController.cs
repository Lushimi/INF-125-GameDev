using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
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

    public void MassEnable()
    {
        var entities = FindObjectsOfType(typeof(EntityControl));
        foreach (EntityControl entity in entities)
        {
            entity.Enable();
        }
        if (verbose) Debug.Log("Enabled all entities.");
    }

    void Start()
    {
        MassDisable();
    }

    public void moveEntity(Rigidbody2D ec, Vector2 moveVector)
    {
        ec.MovePosition(ec.position + moveVector);
    }

    void FixedUpdate()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (cutsceneState == 3)
        {
            float time = 5;
            Vector2 moveVector = new Vector2(0, 10);
            float speed = moveVector.magnitude / time;

            var animator = player.GetComponent(typeof(Animator)) as Animator;
            animator.SetFloat("Horizontal", moveVector.x);
            animator.SetFloat("Vertical", moveVector.y);
            animator.SetFloat("Speed", speed);

            if (timePassed < time) {
                moveEntity((Rigidbody2D)player.GetComponent(typeof(Rigidbody2D)), moveVector.normalized * speed * Time.fixedDeltaTime);
            }
            
            timePassed += Time.fixedDeltaTime;
        }
    }
    //Advances cutsceneState and performs actions that don't need to be done frame by frame
    public void playCutscene()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        
        cutsceneState += 1;

        if (cutsceneState == 7)
        {
            MassEnable();
            cutsceneOver.Raise();
        }
        
    }
}
