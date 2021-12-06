using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneControllerIntro : CutsceneController
{
    public Sprite transformation;
    public GameEvent meleeAttack;
    public GameEvent scream1;
    public GameEvent scream2;
    private bool notPlayed = true;
    public override void resolveContinuousState(int sceneState)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var malefiax = GameObject.Find("Malefiax");
        var animator = player.GetComponent(typeof(Animator)) as Animator;
        var msprite = malefiax.GetComponent<SpriteRenderer>();
        if (sceneState==1)
        {
            float timeMove = 1;
            float timeAttack = 0.5f;
            Vector2 moveVector = new Vector2(0, 1f);
            float speed = moveVector.magnitude / timeMove;

            
            animator.SetFloat("Horizontal", moveVector.x);
            animator.SetFloat("Vertical", moveVector.y);
            animator.SetFloat("Speed", speed);

            if (timePassed < timeMove)
            {
                moveEntity((Rigidbody2D)player.GetComponent(typeof(Rigidbody2D)), moveVector.normalized * speed * Time.fixedDeltaTime);
            }
            else if(timePassed < timeMove+timeAttack)
            {
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", 0);
                animator.SetFloat("Speed", 0);
                animator.SetBool("isMeleeAttacking", true);
                if (notPlayed)
                {
                    meleeAttack.Raise();
                    notPlayed = false;
                } 
                msprite.color = Color.red;
            }
            else
            {
                animator.SetBool("isMeleeAttacking", false);
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", 0);
                animator.SetFloat("Speed", 0);
            }

            timePassed += Time.fixedDeltaTime;
        }

        if (sceneState == 7)
        {
            
            float timeAttack = 0.5f;
            
            if (timePassed < timeAttack)
            {
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", 0);
                animator.SetFloat("Speed", 0);
                animator.SetBool("isMeleeAttacking", true);

                msprite.color = Color.grey;
                
            }
            else
            {
                animator.SetBool("isMeleeAttacking", false);
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", 0);
                animator.SetFloat("Speed", 0);
            }

            timePassed += Time.fixedDeltaTime;
        }
        
    }

    public override void resolveAtomicState(int sceneState)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var magician = GameObject.FindGameObjectWithTag("Player");
        var psprite = player.GetComponent<SpriteRenderer>();
        
        if (sceneState==7)
        {
            meleeAttack.Raise();
        }
        if (sceneState==8)
        {
            var animator = player.GetComponent(typeof(Animator)) as Animator;
            animator.enabled = false;
            scream1.Raise();
            psprite.sprite = transformation;
            var prb =(Rigidbody2D) player.GetComponent(typeof(Rigidbody2D));
            prb.AddForce(new Vector2(0, -2f), ForceMode2D.Impulse);
        }
        if(sceneState==12)
        {
            scream2.Raise();
            player.transform.localScale = new Vector3(1.5f,1.5f,1f);
            knockbackAllAroundObject(player, 2, 1.5f);
        }
        if (sceneState == 22)
        {
            scream2.Raise();
            psprite.color = Color.grey;
            player.transform.localScale = new Vector3(2f, 2f, 2f);
        }
        if (sceneState == 26)
        {
            var mcam = GameObject.Find("Main Camera").GetComponent<CameraController>();
            mcam.SpawnPlayer();
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerData>().PortalChange("HubScene");
        }
    }
}
