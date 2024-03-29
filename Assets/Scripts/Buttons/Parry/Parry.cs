using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : Button
{
    public float startup;
    public float invuln;
    public float endLag;
    public float cooldown => startup + invuln + endLag;
    private PlayerControl PlayerController => transform.parent.gameObject.GetComponent<PlayerControl>();

    internal float staminaCost;

    public virtual void parry()
    {
        StartCoroutine(IParry());
    }

    public IEnumerator IParry()
    {

        //Parry with iframe
        //startup - the time after the parry starts but before the invuln takes effect
        //invuln - duration of iframes
        //endlag - the time where the player can't act even though they are no longer in iframes
        //movementVector - the direction of the parry

        //startup part of parry
        float startupDeltaTime = startup / 75; //literal arbitrary, could use anything else
        for (float i = 0; i < startup; i += startupDeltaTime)
        {
            //gameObject.transform.position += gameObject.GetComponent<PlayerControl>().movementVector.normalized * (speed * startup / (startup + invuln)) * startupDeltaTime;
            yield return new WaitForSeconds(startupDeltaTime);
        }

        //iframe part of dodge
        float invulnDeltaTime = invuln / 75; //literal is arbitrary, could use anything else
        PlayerController.isInvulnerable = true;
        for (float i = 0; i < invuln; i += invulnDeltaTime)
        {
            //gameObject.transform.position += gameObject.GetComponent<PlayerControl>().movementVector.normalized * (speed * invuln / (startup + invuln)) * invulnDeltaTime;
            yield return new WaitForSeconds(invulnDeltaTime);
        }

        PlayerController.isInvulnerable = false;
    }

}
