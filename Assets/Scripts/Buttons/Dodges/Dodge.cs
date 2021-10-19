using System.Collections;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    public float staminaCost;
    public float startup;
    public float invuln;
    public float endLag;
    public float cooldown => startup + invuln + endLag;
    public float dodgeSpeedMultiplier;
    private PlayerControl PlayerController => gameObject.GetComponent<PlayerControl>();
    public float Speed => dodgeSpeedMultiplier * PlayerController.Player.speed;

    public virtual void PerformDodge() {
        //Disable any other actions
        StartCoroutine(IDodge());
    }

    public IEnumerator IDodge()
    {
        //Dodge with iframe
        //staminaCost - cost of dodge in stamina
        //startup - the time after the dodge starts but before the invuln takes effect
        //invuln - duration of iframes
        //endlag - the time where the player can't act even though they are no longer in iframes
        //speed - how fast the character moves during the dodge
        //movementVector - the direction of the dodge

        //startup part of dodge
        float startupDeltaTime = startup / 75; //literal arbitrary, could use anything else
 
        for (float i = 0; i < startup; i += startupDeltaTime)
        {
 
            gameObject.transform.position += PlayerController.movementVector * (Speed * startup / (startup + invuln)) * startupDeltaTime;
            yield return new WaitForSeconds(startupDeltaTime);
        }

        //iframe part of dodge
        float invulnDeltaTime = invuln / 75; //literal is arbitrary, could use anything else
        PlayerController.isInvulnerable = true;
        for (float i = 0; i < invuln; i += invulnDeltaTime)
        {
          
            gameObject.transform.position += PlayerController.movementVector * (Speed * invuln / (startup + invuln)) * invulnDeltaTime;
            yield return new WaitForSeconds(invulnDeltaTime);
        }

        PlayerController.isInvulnerable = false;
    }

}
