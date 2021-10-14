using System.Collections;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    public float staminaCost;
    public float startup;
    public float invuln;
    public float endLag;
    public float dodgeSpeedMultiplier;
    private PlayerData Player => gameObject.GetComponent<PlayerControl>().Player;
    public float Speed => dodgeSpeedMultiplier * Player.speed;

    public virtual void PerformDodge() {
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

        //Disable any other actions
        StartCoroutine(gameObject.GetComponent<PlayerControl>().disableActions(startup + invuln + endLag));

        //startup part of dodge
        float startupDeltaTime = startup / 75; //literal arbitrary, could use anything else
        for (float i = 0; i < startup; i += startupDeltaTime)
        {
            gameObject.transform.position += gameObject.GetComponent<PlayerControl>().movementVector.normalized * (Speed * startup / (startup + invuln)) * startupDeltaTime;
            yield return new WaitForSeconds(startupDeltaTime);
        }

        //iframe part of dodge
        float invulnDeltaTime = invuln / 75; //literal is arbitrary, could use anything else
        Player.isInvulnerable = true;
        for (float i = 0; i < invuln; i += invulnDeltaTime)
        {
            gameObject.transform.position += gameObject.GetComponent<PlayerControl>().movementVector.normalized * (Speed * invuln / (startup + invuln)) * invulnDeltaTime;
            yield return new WaitForSeconds(invulnDeltaTime);
        }

        Player.isInvulnerable = false;
    }

}
