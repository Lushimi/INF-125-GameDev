using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneControllerS1 : CutsceneController
{
    
    public override void resolveContinuousState(int sceneState)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (sceneState == 3)
        {
            float time = 3;
            Vector2 moveVector = new Vector2(0, 10);
            float speed = moveVector.magnitude / time;

            var animator = player.GetComponent(typeof(Animator)) as Animator;
            animator.SetFloat("Horizontal", moveVector.x);
            animator.SetFloat("Vertical", moveVector.y);
            animator.SetFloat("Speed", speed);

            if (timePassed < time)
            {
                moveEntity((Rigidbody2D)player.GetComponent(typeof(Rigidbody2D)), moveVector.normalized * speed * Time.fixedDeltaTime);
            }
            else
            {
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", 0);
                animator.SetFloat("Speed", 0);
            }

            timePassed += Time.fixedDeltaTime;
        }
    }

    public override void resolveAtomicState(int sceneState)
    {
        if (sceneState == 7)
        {
            MassEnable();
            cutsceneOver.Raise();
        }
    }
}
